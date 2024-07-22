using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public GameObject carRef;
    public GameObject backUpCar;
    public GameObject scoreCanvas;
    public static float totalScore;
    private ExitGames.Client.Photon.Hashtable customProperties = new ExitGames.Client.Photon.Hashtable();
    private float time;
    public TextMeshProUGUI timeUI;
    public float timeLimit = 120f;
    private AudioSource audioSource;

    private void Awake()
    {
        customProperties["wheels"] = CustomizationScript.wheelsPrefab.name;
        customProperties["colorr"] = CustomizationScript.mainColor.r;
        customProperties["colorg"] = CustomizationScript.mainColor.g;
        customProperties["colorb"] = CustomizationScript.mainColor.b;

        PhotonNetwork.LocalPlayer.SetCustomProperties(customProperties);
    }

    void Start()
    {
        time = 0f;
        totalScore = 0;
        if (CustomizationScript.carPrefab)
            carRef = PhotonNetwork.InRoom ? PhotonNetwork.Instantiate(CustomizationScript.carPrefab.name, new Vector3(PhotonNetwork.IsMasterClient ? 0 : 30, 10, 0), Quaternion.identity) : Instantiate(CustomizationScript.carPrefab, new Vector3(0, 10, 0), Quaternion.identity);
        else
            carRef = PhotonNetwork.InRoom ? PhotonNetwork.Instantiate(backUpCar.name, new Vector3(PhotonNetwork.IsMasterClient ? 0 : 30, 10, 0), Quaternion.identity) : Instantiate(backUpCar, new Vector3(0, 10, 0), Quaternion.identity);
        carRef.GetComponent<CarController>().controlLock = false;
        Camera.main.GetComponent<CameraScript>().carRef = carRef;
        Camera.main.GetComponent<CameraScript>().enabled = true;
        audioSource = Camera.main.gameObject.AddComponent<AudioSource>();
        audioSource.clip = (AudioClip)Resources.Load("PHONK OSYA 19.07.2024");
        audioSource.loop = true;
        audioSource.volume = PlayerPrefs.GetFloat("volume");
        audioSource.mute = PlayerPrefs.GetInt("music") == 0? true : false;
        audioSource.Play();
        Instantiate(scoreCanvas, carRef.transform.position, carRef.transform.rotation, carRef.transform);
    }

    private void FixedUpdate()
    {
        time += Time.fixedDeltaTime;
        timeUI.text = (timeLimit-time).ToString("F2");
        if (time >= 120f)
            EndMatch();

    }
    void EndMatch()
    {
        PhotonNetwork.Disconnect();
        SceneManager.LoadScene("end");
    }
}
