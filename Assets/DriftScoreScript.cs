using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DriftScoreScript : MonoBehaviour
{
    public TextMeshProUGUI text;
    private CarController controllerRef;
    // Start is called before the first frame update
    void Start()
    {
        text = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        controllerRef = GetComponentInParent<CarController>();
        controllerRef.DriftStart.AddListener(OnStartDrifting);
        controllerRef.DriftStop.AddListener(OnStopDrifting);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(controllerRef.isDrift)
        text.text = controllerRef.driftScore.ToString();
    }

    void OnStartDrifting()
    {
        text.enabled = true;
    }
    void OnStopDrifting()
    {
        this.Invoke("DisableText",3);
    }
    
    void DisableText()
    {
        if (!controllerRef.isDrift)
            text.enabled = false;
    }
}
