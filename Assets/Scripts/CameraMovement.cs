using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    Transform camPos;
    public Transform playPos;
    float cameraDistanceMax = 7f ;
    float cameraDistanceMin = 1f;
    public float cameraDistance = 2f;
    float scrollSpeed = 0.9f;
    // Use this for initialization
    void Start () {
        camPos = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        cameraDistance -= Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;
        cameraDistance = Mathf.Clamp(cameraDistance, cameraDistanceMin, cameraDistanceMax);
        camPos.localPosition = new Vector3(camPos.localPosition.x,camPos.localPosition.y,-1*cameraDistance);
        
    }
}
