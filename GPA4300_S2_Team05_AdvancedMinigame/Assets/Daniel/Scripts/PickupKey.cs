using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupKey : MonoBehaviour
{
    [SerializeField] private string notification;
    [SerializeField] MoveObject lockedThing;
    private AudioSource soundEffect;


    private void Start()
    {
        soundEffect = GetComponent<AudioSource>();       
    }

    public void Pickup()
    {
        soundEffect.Play();
        FindObjectOfType<TextAnimator>().Show(notification);
            lockedThing.Locked(false);
            Destroy(gameObject);       
    }
}
