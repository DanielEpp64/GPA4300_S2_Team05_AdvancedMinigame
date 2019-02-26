using UnityEngine;
using System.Collections;



public class Interactor : MonoBehaviour
{
    [SerializeField] private float range;

    private MoveObject Object;
    private PickupKey Key;
    private Lightswitch Button;
    private Note Note;

    private Camera cam;
    private RaycastHit ray;
    private InteractIcon activeIcon;


    void Start ()
    {
        cam = Camera.main;
        activeIcon = GameObject.FindObjectOfType<InteractIcon>();
    }
	
	void Update ()
    {
        Physics.Raycast(cam.transform.position, cam.transform.forward, out ray, range);

        MoveObject();
        PickupKey();
        Lightswitch();
    }


    void MoveObject()
    {
        if (ray.transform.gameObject.tag == "Object")
        {
            Object = ray.transform.GetComponent<MoveObject>();
            Debug.Log("rayHitDoor");
        }
        else
        {
            Object = null;
        }

        activeIcon.ChangeIcon(Object, Key);

        if (Input.GetButtonDown("Interact"))
        {
            if (Object)
            {
                Object.Move();
            }
        }
    }


    void PickupKey()
    {
        if (ray.transform.gameObject.tag == "Key")
        {
            Key = ray.transform.GetComponent<PickupKey>();
            Debug.Log("rayHitKey");
        }
        else
        {
            Key = null;
        }

        activeIcon.ChangeIcon(Object, Key);

        if (Input.GetButtonDown("Interact"))
        {
            if (Key)
            {
                Key.Pickup();
            }
        }
    }


    void Lightswitch()
    {
        if (ray.transform.gameObject.tag == "Button")
        {
            Button = ray.transform.GetComponent<Lightswitch>();
            Debug.Log("rayHitButton");
        }
        else
        {
            Button = null;
        }

        activeIcon.ChangeIcon(Button, Key);

        if (Input.GetButtonDown("Interact"))
        {
            if (Button)
            {
                Button.FlipLightswitch();
            }
        }
    }


    void ReadNote()
    {
        if (ray.transform.gameObject.tag == "Note")
        {
            Note = ray.transform.GetComponent<Note>();
            Debug.Log("rayHitNote");
        }
        else
        {
            Note = null;
        }

        activeIcon.ChangeIcon(Note, Key);

        if (Input.GetButtonDown("Interact"))
        {
            if (Note)
            {
                Note.ReadNote();
            }
        }
    }
}
