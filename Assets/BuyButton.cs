using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyButton : MonoBehaviour
{
    public static GameObject carPrefab;
    public ShopManager shopRef;
    public GarageCarHandler spawnerRef;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(TaskOnClick);
    }

    private void TaskOnClick()
    {
        if(shopRef.Unlock(carPrefab.GetComponent<Stats>().ID,carPrefab.GetComponent<Stats>().cost))
        {
            spawnerRef.ChangeCar(carPrefab);
            shopRef.UpdateCash();
            gameObject.SetActive(false);

        }
    }
}
