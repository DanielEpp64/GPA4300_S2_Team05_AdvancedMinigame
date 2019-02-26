using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class TextAnimator : MonoBehaviour
{
    private Text notification;
    [SerializeField] private float secondsVisible = 2f;
    [SerializeField] private float secondsSinceVisible = 0;
    private bool visible = false;
	

	void Start ()
    {
        notification = GetComponent<Text>();
	}
	
	void Update ()
    {
		if (secondsSinceVisible >= secondsVisible)
        {
            Visibility(false);
            visible = false;
        }

        else if (visible)
        {
            secondsSinceVisible += Time.deltaTime;
        }
	}


    public void Show(string text)
    {
        Visibility (true);
        notification.text = text;
        secondsSinceVisible = 0;
        visible = true;
    }

    private void Visibility (bool showing)
    {
        Color color = notification.color;
        color.a = showing ? 1 : 0;
        notification.color = color;
    }
}
