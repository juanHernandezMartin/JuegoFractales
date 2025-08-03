using System.Collections.Generic;
using UnityEngine;

public class Fractal : MonoBehaviour
{
    public Transform modelHandler;
    public GameObject model;
    public List<Transform> children = new List<Transform>();
    public List<Transform> ActiveChildren = new List<Transform>();
    [HideInInspector]
    public List<bool> isChildActive = new List<bool>();

    public void Start()
    {
        isChildActive.Add(false);
        isChildActive.Add(false);
        isChildActive.Add(false);
        isChildActive.Add(false);
    }

    public int GetFirstInactiveChildIndex()
    {
        for (int i = 0; i < isChildActive.Count; i++)
        {
            if (!isChildActive[i])
            {
                return i;
            }
        }
        return -1; // All children are active
    }
}
