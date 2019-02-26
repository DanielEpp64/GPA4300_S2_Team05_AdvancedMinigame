using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candle : MonoBehaviour {

    //private Animator anim;

    public GameObject lightsource;
    public GameObject candle;

    public bool candleEnabled;

    int lightOut;

    private void Start()
    {
        lightsource.transform.GetComponentInChildren<Light>();
        //anim = GetComponent<Animator>();
        lightOut = Random.Range(1, 6);
    }

    void Update ()
    {
		if (Input.GetButtonDown("Use"))
        {
            lightsource.SetActive(true);
            candleEnabled = true;
        }

        //if (candleEnabled == true)
        //{
        //    anim.Play("Burning");
        //}
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            lightsource.SetActive(false);
            candleEnabled = false;
        }
        Debug.Log("BurnTime: " + lightOut);
    }

    IEnumerator BurnTime()
    {
        if (candleEnabled)
        {
            switch (lightOut)
            {
                case 1:
                    lightsource.SetActive(true);
                    yield return new WaitForSecondsRealtime(10f);
                    lightsource.SetActive(false);
                    candleEnabled = false;
                    break;
                case 2:
                    lightsource.SetActive(true);
                    yield return new WaitForSecondsRealtime(35f);
                    lightsource.SetActive(false);
                    candleEnabled = false;
                    break;
                case 3:
                    lightsource.SetActive(true);
                    yield return new WaitForSecondsRealtime(60f);
                    lightsource.SetActive(false);
                    candleEnabled = false;
                    break;
                case 4:
                    lightsource.SetActive(true);
                    yield return new WaitForSecondsRealtime(100f);
                    lightsource.SetActive(false);
                    candleEnabled = false;
                    break;
                case 5:
                    lightsource.SetActive(true);
                    yield return new WaitForSecondsRealtime(120f);
                    lightsource.SetActive(false);
                    candleEnabled = false;
                    break;
                case 6:
                    lightsource.SetActive(true);
                    yield return new WaitForSecondsRealtime(230f);
                    lightsource.SetActive(false);
                    candleEnabled = false;
                    break;
            }
        }
    }

    public void destroycandle ()
    {
        Destroy(candle);
    }
}