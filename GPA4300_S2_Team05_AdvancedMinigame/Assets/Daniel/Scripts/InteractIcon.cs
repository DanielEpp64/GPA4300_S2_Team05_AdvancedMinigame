using UnityEngine;
using System.Collections;



public class InteractIcon : MonoBehaviour
{
    public GameObject defaultIcon;
    public GameObject interactIcon;
    public GameObject pickupIcon;


    void Start ()
    {
        interactIcon.SetActive(false);
        pickupIcon.SetActive(false);
    }


    public void ChangeIcon(bool isObject, bool isCollectable)
    {
        defaultIcon.SetActive(!isObject && !isCollectable);
        interactIcon.SetActive(isObject && !isCollectable);
        pickupIcon.SetActive(isCollectable && !isObject);
    }
}
