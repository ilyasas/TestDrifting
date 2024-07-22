using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GarageCarHandler : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject carPrefab;
    public GameObject wheelPrefab;
    public GameObject carRef;

    void Start()
    {
        SpawnCar(CustomizationScript.carPrefab);
    }

    public void SpawnCar(GameObject car, bool changeStatic = false)
    {
        if(changeStatic)
            CustomizationScript.carPrefab = car;
        carRef = Instantiate(car, new Vector3(0,0,0),new Quaternion(0,0,0,0));
        carRef.GetComponent<CarController>().controlLock = true;
    }

    public void ChangeWheels(GameObject wheels)
    {
        carRef.GetComponent<PrefabSpawner>().SwapWheels(wheels);
        CustomizationScript.wheelsPrefab = wheels;
    }
    public void ChangeColorWhite()
    {
        carRef.GetComponent<PrefabSpawner>().SetColor(Color.white);
        CustomizationScript.mainColor = Color.white;

    }

    public void ChangeColorRed()
    {
        carRef.GetComponent<PrefabSpawner>().SetColor(Color.red);
        CustomizationScript.mainColor = Color.red;
    }

    public void ChangeColor(Color col)
    {
        carRef.GetComponent<PrefabSpawner>().SetColor(col);
        CustomizationScript.mainColor = col;
    }

    public void ChangeCar(GameObject car)
    {
        Destroy(carRef);
        SpawnCar(car,true);
    }
    public void CheckCar(GameObject car)
    {
        Destroy(carRef);
        SpawnCar(car, false);
    }
    public void LoadScene(string name)
    {
        GetComponent<SaveManager>().Save();
        SceneManager.LoadScene(name);
    }
}
