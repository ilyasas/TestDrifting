using UnityEngine;
using UnityEngine.UI;

public class ShopButton : MonoBehaviour
{
    public GameObject carPrefab;
    public GameObject buyButtonRef;
    public GarageCarHandler spawnerRef;
    public ShopManager shopRef;
    private void Start()
    {
        
        Debug.Log(buyButtonRef);
    }

    public void TaskOnClick()
    {
        if (shopRef.Check(carPrefab.GetComponent<Stats>().ID))
        {
            spawnerRef.ChangeCar(carPrefab);
            buyButtonRef.SetActive(false);
        }
        else
        {
            spawnerRef.CheckCar(carPrefab);
            BuyButton.carPrefab = carPrefab;
            buyButtonRef.SetActive(true);
        }
    }
}
