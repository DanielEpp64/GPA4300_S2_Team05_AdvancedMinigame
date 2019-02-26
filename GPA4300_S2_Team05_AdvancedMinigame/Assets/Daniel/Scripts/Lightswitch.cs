using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Lightswitch : MonoBehaviour
{
    private AudioSource soundEffect;
    [SerializeField] GameObject LightSource;
    private bool on = false;


    private void Start()
    {
        soundEffect = GetComponent<AudioSource>();
        LightSource = GetComponent<GameObject>();
    }


    public void FlipLightswitch()
    {
        if (!on)
        {
            soundEffect.Play();
            LightSource.SetActive(true);
        }
        else
        {
            soundEffect.Play();
            LightSource.SetActive(false);
        }
    }
}
