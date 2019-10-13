using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extensions
{
    public static Vector2[] ToVector2Array(this List<Vector3> list)
    {
        Vector2[] returnValue = new Vector2[list.Count];
        for (int i = 0; i < list.Count; i++)
            returnValue[i] = new Vector2(list[i].x, list[i].y);
        return returnValue;
    }

    public static Vector2[] ToVector2Array(this Vector3[] list)
    {
        Vector2[] returnValue = new Vector2[list.Length];
        for (int i = 0; i < list.Length; i++)
            returnValue[i] = new Vector2(list[i].x, list[i].y);
        return returnValue;
    }

    public static List<Vector3> ToVector2List(this Vector3[] list)
    {
        List<Vector3> returnValue = new List<Vector3>();
        for (int i = 0; i < list.Length; i++)
            returnValue.Add(new Vector2(list[i].x, list[i].y));
        return returnValue;
    }
}
