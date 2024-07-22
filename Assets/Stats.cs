using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public string ID;
    public int cost;

    [ContextMenu("Generate ID")]
    void GenerateId()
    {
        ID = System.Guid.NewGuid().ToString();

    }
}
