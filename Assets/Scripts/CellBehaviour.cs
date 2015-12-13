using UnityEngine;
using System.Collections;

public class CellBehaviour : MonoBehaviour
{
    public static int frameTime = 0;
    public static int splitsInFrame = 0;
    public float size = 10.0f;
    public float maxSize = 10.0f;
    public float minSize = 1.0f;
    public float shrinkRate = 1.0f;
    public float splitSize = 5.0f;
    public float splitForce = 3;
    public bool isChain = false;

    public GameObject splitObject;
    // Use this for initialization
    void Start()
    {
        splitsInFrame = 0;
        CellCounter.OnCellCreated(tag);
    }

    public void OnDestroy()
    {
        CellCounter.OnCellDestroyed(tag);
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(
            size, size, size
        );
        Grow(Time.deltaTime * -shrinkRate);
    }

    public void Grow(float size)
    {
        var newSize = this.size + size;
        newSize = Mathf.Min(newSize, maxSize);
        if (newSize < minSize)
            Destroy(gameObject);
        this.size = newSize;
        if (this.size >= splitSize)
            Split();
    }

    public GameObject Clone()
    {
        if (frameTime != Time.frameCount)
        {
            frameTime = Time.frameCount;
            splitsInFrame = 0;
        }
        if (splitsInFrame > 10) return null;
        splitsInFrame++;

        var splitCell = (GameObject)Instantiate(splitObject, this.transform.position, this.transform.rotation);
        splitCell.name = this.gameObject.name;
        splitCell.tag = this.gameObject.tag;
        return splitCell;
    }

    public void Split()
    {
        var angle = Random.insideUnitCircle.ToVector3();
        var splitCell = Clone();
        if (splitCell == null) return;
        splitCell.transform.rotation = Quaternion.AngleAxis(Random.Range(0, 360), Vector3.forward);
        splitCell.GetComponent<Rigidbody2D>().velocity = angle * splitForce;
        this.GetComponent<Rigidbody2D>().velocity = angle * -splitForce;

        var otherSize = Random.Range(minSize, this.size - minSize);
        this.size = this.size - otherSize;
        splitCell.GetComponent<CellBehaviour>().size = otherSize;

        if (isChain)
        {
            SpringJoint2D spring = splitCell.GetComponent<SpringJoint2D>();
            spring.enabled = true;
            spring.connectedBody = GetComponent<Rigidbody2D>();
        }
    }


}
