using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ObjectExtension
{

    private static List<GameObject> savedObjects = new List<GameObject>();

    public static void DontDestroyOnLoad(this GameObject obj)
    {
        savedObjects.Add(obj);
        Object.DontDestroyOnLoad(obj);
    }

    public static void Destroy(this GameObject obj)
    {
        savedObjects.Remove(obj);
        Destroy(obj);
    }

    public static List<GameObject> GetSavedObjects()
    {
        return new List<GameObject>(savedObjects);
    }
    public static GameObject GetSavedObjectByName(string name)
    {
        foreach (var item in savedObjects)
        {
            if (item.name == name) { return item; }
        }
        return null;
    }
}
