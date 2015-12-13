using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public static class Extensions
{
    public static Vector2 Average(this IEnumerable<Vector2> vectors)
    {
        Vector2 result = Vector2.zero;
        int count = 0;
        foreach (Vector2 v in vectors)
        {
            result += v;
            count++;
        }
        return result / (float)count;
    }

    public static T Pick<T>(this IList<T> items)
    {
        Assert.AreNotEqual(0, items.Count);
        return items[UnityEngine.Random.Range(0, items.Count)];
    }

    public static T Pick<T>(this T[] items)
    {
        Assert.AreNotEqual(0, items.Length);
        return items[UnityEngine.Random.Range(0, items.Length)];
    }

    public static void PlayAny(this AudioSource audioSource, AudioClip[] audioClips)
    {
        audioSource.PlayOneShot(audioClips.Pick());
    }

    public static void PlayAny(this AudioSource audioSource, IList<AudioClip> audioClips)
    {
        audioSource.PlayOneShot(audioClips.Pick());
    }

    public static Vector3 ToVector3(this Vector2 v)
    {
        return new Vector3(v.x, v.y);
    }

    public static Vector2 ToVector2(this Vector3 v)
    {
        return new Vector2(v.x, v.y);
    }

    public static Vector3 ScreenToPlane(this Camera camera, Vector3 screenPosition, Plane plane)
    {
        Ray ray = Camera.main.ScreenPointToRay(screenPosition);
        float distance;
        plane.Raycast(ray, out distance);
        var mousePosition = ray.GetPoint(distance);
        return mousePosition;
    }

    public static Vector3 ScreenToPlane(this Camera camera, Vector3 screenPosition)
    {
        return ScreenToPlane(camera, screenPosition, new Plane(Vector3.forward, Vector3.zero));
    }
}