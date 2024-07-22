using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public GameObject[] carList;
    public TextMeshProUGUI cashRef;
    public static List<string> unlocked;

    private void Awake()
    {
        UpdateCash();
    }

    public void UpdateCash()
    {
        cashRef.text = "Cash: " + CustomizationScript.cash.ToString();
    }

    public void AddCash(int cash)
    {
        CustomizationScript.cash += cash;
        UpdateCash();
    }

    public bool Check(string id)
    {
        return unlocked.Contains(id);
    }

    public bool Unlock(string id,int cost)
    {
        if (!Check(id) && cost < CustomizationScript.cash)
        {
            ShopManager.unlocked.Add(id);
            CustomizationScript.cash += -cost;
            return true;
        }
        return false;
    }
}
