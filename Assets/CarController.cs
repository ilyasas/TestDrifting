using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.Events;

public class CarController : MonoBehaviour
{
    public bool controlLock;
    public float torque = 1000;
    public float brake = 100000;
    [Range (0,90)] public float steerAngle;
    public GameObject wheelPrefab;
    public WheelCollider[] wheelsFront;
    public WheelCollider[] wheelsRear;
    private WheelCollider[] wheels;
    public Transform[] wheelsMesh;
    private PrefabSpawner prefabSpawner;
    private float slip;
    private Rigidbody rbRef;
    [HideInInspector] public bool isDrift = false;
    [HideInInspector] public float driftScore;
    public UnityEvent DriftStart;
    public UnityEvent DriftStop;
    private PhotonView photonView;
    public Material colorMatRef;

    void Start()
    {
        photonView = GetComponent<PhotonView>();
        prefabSpawner = GetComponent<PrefabSpawner>();
        rbRef = GetComponent<Rigidbody>();
        wheels = new WheelCollider[wheelsFront.Length + wheelsRear.Length];
        wheelsFront.CopyTo(wheels,0);
        wheelsRear.CopyTo(wheels, wheelsRear.Length);
        if (PhotonNetwork.InRoom)
        {
            prefabSpawner.SpawnWheels((string)photonView.Owner.CustomProperties["wheels"]);
            prefabSpawner.SetColor(new Color((float)photonView.Owner.CustomProperties["colorr"], (float)photonView.Owner.CustomProperties["colorg"], (float)photonView.Owner.CustomProperties["colorb"]));
        }
        else
        {
            prefabSpawner.SpawnWheels(CustomizationScript.wheelsPrefab);
            prefabSpawner.SetColor(CustomizationScript.mainColor);
        }
            
        UpdateWheelMesh();
    }

    void FixedUpdate()
    {
        if(!controlLock)
        {
            SolveTorque();
            SolveSteer();
            slip = Vector3.Angle(transform.forward, rbRef.velocity - transform.forward);
            Drift();
            Brake();
            UpdateWheelMesh();
        }

    }

    void SolveTorque()
    {
        foreach (WheelCollider wheel in wheelsRear)
        {
            wheel.motorTorque = Input.GetAxis("Vertical") * torque;
        }
    }

    void SolveSteer()
    {
        var steer = Input.GetAxis("Horizontal") * steerAngle;
        if (slip < 120f && slip>5f)
        {
            steer += Mathf.Lerp(Vector3.SignedAngle(transform.forward, rbRef.velocity + transform.forward, Vector3.up),0 , 0.1f);
        }
        foreach (WheelCollider wheel in wheelsFront)
        {
            wheel.steerAngle = steer;
        }
    }

    void UpdateWheelMesh() 
    { 
        for (int i = 0; i< wheels.Length;i++)
        {
            Vector3 pos;
            Quaternion rot;
            wheels[i].GetWorldPose(out pos, out rot);
            wheelsMesh[i].transform.position = pos;
            wheelsMesh[i].transform.rotation = rot;
        }

    }
    
    void Brake()
    {
        foreach (WheelCollider wheel in wheelsRear)
        {
            wheel.brakeTorque = Input.GetAxis("Jump") * brake;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(GetComponent<Rigidbody>().centerOfMass+transform.position, 0.3f);
    }

    void Drift()
    {
        if(slip>20f && !isDrift)
        {
            isDrift = true;
            DriftStart.Invoke();

        }
        if(isDrift)
        {
            driftScore += Mathf.Round(Time.fixedDeltaTime*1*rbRef.velocity.magnitude);
            if (slip < 20f || slip > 160f || rbRef.velocity.magnitude < 5f)
            {
                isDrift = false;
                Debug.Log(driftScore);
                LevelManager.totalScore += driftScore;
                DriftStop.Invoke();
                driftScore = 0;
            }
        }
    }
}
