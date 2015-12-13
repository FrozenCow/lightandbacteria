using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class CellCounter {

    private static Dictionary<string, int> counts = new Dictionary<string, int>();
    public static void OnCellCreated(string tag)
    {
        int count;
        counts.TryGetValue(tag, out count);
        counts[tag] = count + 1;
    }

    public static void OnCellDestroyed(string tag)
    {
        int count;
        counts.TryGetValue(tag, out count);
        counts[tag] = count - 1;
    }

    public static int GetCount(string tag)
    {
        int count;
        counts.TryGetValue(tag, out count);
        return count;
    }
}
