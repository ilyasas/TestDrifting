using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float torque = 1000;
    public float brake = 100000;
    [Range (0,90)] public float steerAngle;
    public GameObject wheelPrefab;
    public WheelCollider[] wheelsFront;
    public WheelCollider[] wheelsRear;
    private WheelCollider[] wheels;
    public Transform[] wheelsMesh;

    void Start()
    {
        wheels = new WheelCollider[wheelsFront.Length + wheelsRear.Length];
        wheelsFront.CopyTo(wheels,0);
        wheelsRear.CopyTo(wheels, wheelsRear.Length);

        foreach(Transform wheel in wheelsMesh)
        {
            Instantiate(wheelPrefab, wheel.position, Quaternion.Euler(0, 0, 0), wheel);
        }
    }

    void FixedUpdate()
    {
        SolveTorque();
        SolveSteer();
        UpdateWheelMesh();
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
        if (Vector3.Angle(transform.forward, GetComponent<Rigidbody>().velocity - transform.forward) < 120f)
        {
            steer += Vector3.SignedAngle(transform.forward, GetComponent<Rigidbody>().velocity + transform.forward, Vector3.up);
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

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(GetComponent<Rigidbody>().centerOfMass+transform.position, 0.3f);
    }
}
