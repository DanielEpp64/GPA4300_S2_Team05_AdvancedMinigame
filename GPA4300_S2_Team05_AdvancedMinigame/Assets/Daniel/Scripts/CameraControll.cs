using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class CameraControll : MonoBehaviour
{
    public enum RotationAxes {MouseXandY = 0, MouseX = 1, MouseY = 2}
    public RotationAxes axes = RotationAxes.MouseXandY;

    public float sensitivityX = 5F;
    public float sensitivityY = 5F;

    public float minY = -60F;
    public float maxY = 60F;

    float rotationY = 0F;


    void Update()
    {
        if (axes == RotationAxes.MouseXandY)
        {
            float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;

            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            rotationY = Mathf.Clamp(rotationY, minY, maxY);

            transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
        }
        else if (axes == RotationAxes.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
        }
        else
        {
            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            rotationY = Mathf.Clamp(rotationY, minY, maxY);

            transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
        }
    }
}