using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Note : MonoBehaviour
{
    private AudioSource soundEffect;
    public AudioClip pickUpSound;
    public AudioClip putDownSound;
    public GameObject note;
	public Text text;
	public bool isReading;


	void Start()
    {
		note.SetActive (false);
		text.enabled = false;
	}

	void Update()
    {
		if (isReading)
        {
			if (Input.GetKeyDown("escape"))
            {
                soundEffect.clip = putDownSound;
                soundEffect.Play();
				note.SetActive (false);
				text.enabled = false;
				isReading = false;
				Time.timeScale = 1;
			}
		}
	}


    public void ReadNote()
    {
        text.enabled = true;
        if (!isReading)
        {
                soundEffect.clip = pickUpSound;
                soundEffect.Play();
                note.SetActive(true);
                isReading = true;
                Time.timeScale = 0;         
        }
    }
}
