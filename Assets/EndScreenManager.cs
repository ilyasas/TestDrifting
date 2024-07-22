using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndScreenManager : MonoBehaviour
{
    public TextMeshProUGUI scoreRef;
    public TextMeshProUGUI cashRef;
    public int cash;
    private void Start()
    {
        cash = Mathf.RoundToInt(LevelManager.totalScore/10);
        scoreRef.text = LevelManager.totalScore.ToString();
        cashRef.text = cash.ToString();
    }
    public void Double() 
    {
        cash *= 2;
        cashRef.text = cash.ToString();
    }
    public void AddCash()
    {
        CustomizationScript.cash += cash;
    }

    public void Save()
    {
        GetComponent<SaveManager>().Save();
    }
}
