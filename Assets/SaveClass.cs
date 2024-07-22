using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[System.Serializable]
public class SaveClass
{
    public int cash;
    public string wheelsPrefabPath;
    public string carPrefabPath;
    public List<string> unlocked;
    public Color color;

    public SaveClass(bool check)
    {
        cash = CustomizationScript.cash;
        wheelsPrefabPath = CustomizationScript.wheelsPrefab.name;
        carPrefabPath = CustomizationScript.carPrefab.name;
        color = CustomizationScript.mainColor;
        unlocked = ShopManager.unlocked;
    }
    public SaveClass()
    {

    }
}