using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
    public static void Shuffle<T>(this IList<T> list)
    {
        for (var i = 0; i < list.Count; ++i)
        {
            var rand = Random.Range(0, list.Count - i);
            var temp = list[i];
            list[i] = list[rand];
            list[rand] = temp;
        }
    }

    public static void Backfill<T>(this IList<T> list, int targetCount)
    {
        var originalCount = list.Count;
        while (list.Count < targetCount)
        {
            var rand = Random.Range(0, originalCount);
            list.Add(list[rand]);
        }
    }

    public static void RemoveExcess<T>(this IList<T> list, int targetCount)
    {
        while (list.Count > targetCount && list.Count > 0)
        {
            list.RemoveAt(list.Count - 1);
        }
    }

    public static void SetLocalY(this Transform tr, float newY)
    {
        var pos = tr.localPosition;
        pos.y = newY;
        tr.localPosition = pos;
    }
}