using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEvent : MonoBehaviour
{
    [HideInInspector] public PlayerControll player;
    public GameObject Platform;

    private void OnCollisionEnter(Collision button)
    {
        if (button.gameObject.tag == "Player")
        {
            Mathf.Lerp(0, -1, 0);
            //Platform.transform.position = Mathf.Lerp(0, 0, 2);
        }
    }
}
