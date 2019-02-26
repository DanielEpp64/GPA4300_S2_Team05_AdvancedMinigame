using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(AudioSource))]
public class FootStepSound : MonoBehaviour
{
    public AudioClip[] footStepSounds;
    public float minInterval = 0.1f;
    public float maxVelocity = 8.0f;
    public float bias = 1.1f;
    public AudioSource footStepSound;
    private bool isGrounded;
    private Rigidbody player;


    void Awake()
    {
        player = GetComponent<Rigidbody>();
    }


    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.name == "Ground")
        {
            isGrounded = true;
        }
    }


    IEnumerator Start()
    {
        while (true)
        {
            float speed = player.velocity.magnitude;
            if (isGrounded && speed > 0.2f)
            {
                footStepSound.clip = footStepSounds[Random.Range(0, footStepSounds.Length)];
                footStepSound.Play();
                float interval = minInterval * (maxVelocity + bias) / (speed + bias);
                yield return new WaitForSeconds(interval);
            }
            else
            {
                yield return 0;
            }
        }
    }
}