using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CameraHeadbob : MonoBehaviour
{
    public Vector3 standingPosition;
    public float transitionSpeed = 20f;
    public float intensity = 4.8f;
    public float amount = 0.05f;
    float sinusVar = Mathf.PI / 2;
    Vector3 cam;


    void Awake()
    {
        cam = transform.localPosition;
    }

    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            sinusVar += intensity * Time.deltaTime;
            Vector3 position = new Vector3(Mathf.Cos(sinusVar) * amount, standingPosition.y + Mathf.Abs((Mathf.Sin(sinusVar) * amount)), standingPosition.z);
            cam = position;
        }
        else
        {
            sinusVar = Mathf.PI / 2;
            Vector3 position = new Vector3(Mathf.Lerp(cam.x, standingPosition.x, transitionSpeed * Time.deltaTime), Mathf.Lerp(cam.y, standingPosition.y, transitionSpeed * Time.deltaTime), Mathf.Lerp(cam.z, standingPosition.z, transitionSpeed * Time.deltaTime));
            cam = position;
        }

        if (sinusVar > Mathf.PI * 2)
            sinusVar = 0;
    }
}