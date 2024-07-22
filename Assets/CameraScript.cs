using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {
    
    private bool MouseClick = false;
    public float cameraRotateSpeed = 5f;
    public GameObject carRef;
    public float distance;
    public float height;

	void Start () 
    {

	}
	
	void FixedUpdate () {
       if (carRef!=null)
        {
            Rotate();
            Move();
        }
    }

    void Rotate()
    {
        if (Input.GetMouseButtonDown(0))
            MouseClick = true;
        if (Input.GetMouseButtonUp(0))
            MouseClick = false;

        if (MouseClick)
            transform.RotateAround(carRef.transform.position, carRef.transform.up, Input.GetAxis("Mouse X") * cameraRotateSpeed);
        else
            transform.LookAt(carRef.transform);
    }
    private void Move()
    {
        transform.position = Vector3.Lerp(carRef.transform.forward * -distance+carRef.transform.position + Vector3.up * height, transform.position,0.85f);
    }
}
