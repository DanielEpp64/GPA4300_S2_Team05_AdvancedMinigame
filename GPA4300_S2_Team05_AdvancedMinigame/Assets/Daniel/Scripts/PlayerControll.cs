using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(Rigidbody))]
public class PlayerControll : MonoBehaviour
{
    public float walkSpeed;
    public float runSpeed;
    public float currentStamina;
    public float maxStamina;
    [HideInInspector] public bool controllable;
    [HideInInspector] public bool isMoving;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        isMoving = false;
        currentStamina = maxStamina;
    }


    void Update()
    {
        if(Input.GetKey("left shift") && currentStamina > 0)
        {
            float xMovement = Input.GetAxis("Horizontal") * runSpeed * Time.deltaTime;
            float zMovement = Input.GetAxis("Vertical") * runSpeed * Time.deltaTime;
            currentStamina -= 3 * Time.fixedDeltaTime;
            transform.Translate(xMovement, 0, zMovement);
            // pulse += 5 * Time.fixedDeltaTime;
        }
        else
        {
            float xMovement = Input.GetAxis("Horizontal") * walkSpeed * Time.deltaTime;
            float zMovement = Input.GetAxis("Vertical") * walkSpeed * Time.deltaTime;
            transform.Translate(xMovement, 0, zMovement);
        }
        if (currentStamina < maxStamina)
        {
            currentStamina += 0.2f * Time.fixedDeltaTime;
        }

        /*if(Input.GetKeyDown("escape") || (Input.GetButtonDown("Inventar"))
        {
            Cursor.lockState = CursorLockMode.None;
        }
        */
    }
}
