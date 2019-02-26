using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [HideInInspector] public PlayerControll player;
    [HideInInspector] public bool little;

    public GameObject Player1;
    public GameObject Player2;

    private void OnTriggerEnter(Collider shrink)
    {
        if (shrink.gameObject == Player1 || shrink.gameObject == Player2)
        {
            
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
