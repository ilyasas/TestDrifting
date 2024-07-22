using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class MainMenuManagerScript : MonoBehaviour
{
    SaveClass loadData = null;
    public GameObject[] prefabList;
    public GameObject defaultCar;
    public GameObject defaultWheels;

    private void Start()
    {

        loadData = GetComponent<SaveManager>().Load();
        Debug.Log(loadData);
        if (loadData!=null)
        {
            CustomizationScript.cash = loadData.cash;
            CustomizationScript.mainColor = loadData.color;
            CustomizationScript.carPrefab = Resources.Load<GameObject>(loadData.carPrefabPath);
            CustomizationScript.wheelsPrefab = Resources.Load<GameObject>(loadData.wheelsPrefabPath);
            ShopManager.unlocked = loadData.unlocked;      
        }
        else
        {
            CustomizationScript.cash = 100000;
            CustomizationScript.mainColor = Color.white;
            CustomizationScript.carPrefab = defaultCar;
            CustomizationScript.wheelsPrefab = defaultWheels;
            ShopManager.unlocked = new List<string>();
            ShopManager.unlocked.Add("b482a947-fe7d-46f4-88e3-b883d4509bcf");
        }   
    }
    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
