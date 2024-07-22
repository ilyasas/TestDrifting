using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{
    public Transform[] wheelsMesh;
    public Material colorMatRef;

    void Awake()
    {
        wheelsMesh = GetComponent<CarController>().wheelsMesh;
        colorMatRef = GetComponent<CarController>().colorMatRef;
    }

    public void SpawnWheels(GameObject wheelPref)
    {
        foreach (Transform wheel in wheelsMesh)
        {
            Instantiate(wheelPref, wheel.position, transform.rotation * wheel.GetChild(0).rotation, wheel);
        }

    }
    public void SpawnWheels(string wheelName)
    {
        foreach (Transform wheel in wheelsMesh)
        {
            Instantiate(Resources.Load<GameObject>(wheelName), wheel.position, transform.rotation * wheel.GetChild(0).rotation, wheel);
        }
    }

    public void DeleteWheels()
    {
        foreach (Transform wheel in wheelsMesh)
        {
            Destroy(wheel.GetChild(1).gameObject);
        }
    }

    public void SwapWheels(GameObject wheelPref)
    {
        DeleteWheels();
        SpawnWheels(wheelPref);
    }

    public void SetColor(Color col)
    {
        colorMatRef.color = col;
    }
    public void SwapWheels(string wheelName)
    {
        DeleteWheels();
        SpawnWheels(wheelName);
    }
}
