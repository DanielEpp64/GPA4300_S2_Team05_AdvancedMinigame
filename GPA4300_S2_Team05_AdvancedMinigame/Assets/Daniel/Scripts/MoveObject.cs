using UnityEngine;
using System.Collections;



public class MoveObject : MonoBehaviour
{
    private Hashtable iTween;

    [SerializeField] private Vector3 openPosition;
    [SerializeField] private Vector3 closedPosition;
    [SerializeField] private float animationTime;
    [SerializeField] private MoveObject lockedObject;
    [SerializeField] private bool open = false;
    [SerializeField] private bool locked = false;
    [SerializeField] private bool gotKey;
    [SerializeField] private MovementType movementType;
        private enum MovementType { Slide, Rotate };

        private AudioSource soundEffect;
    [SerializeField] private AudioClip openingSound;
    [SerializeField] private AudioClip lockedSound;
    private TextAnimator textAnimator;
    [SerializeField] private string notification;


    void Start()
    {
        iTween = global::iTween.Hash();
        iTween.Add("position", openPosition);
        iTween.Add("time", animationTime);
        iTween.Add("islocal", true);

        soundEffect = GetComponent<AudioSource>();
        textAnimator = FindObjectOfType<TextAnimator>();
    }


    public void Move()
    {
        if (!locked)
        {
            if (soundEffect)
            {
                soundEffect.clip = openingSound;
                soundEffect.Play();
            }
            if (Input.GetButtonDown("Interact"))
            {
                if (open)
                {
                    iTween["position"] = closedPosition;
                    iTween["rotation"] = closedPosition;
                }
                else
                {
                    iTween["position"] = openPosition;
                    iTween["rotation"] = openPosition;
                }

                    open = !open;
                    OpenOrLocked(open);

                switch (movementType)
                {
                    case MovementType.Slide:
                    global::iTween.MoveTo(gameObject, iTween);
                    break;

                    case MovementType.Rotate:
                    global::iTween.RotateTo(gameObject, iTween);
                    break;
                }
            }
        }
        else
        {
            textAnimator.Show(notification);
            soundEffect.clip = lockedSound;
            soundEffect.Play();
        }
    }


    private void OpenOrLocked(bool lockIt)
    {
        if (lockedObject)
        {
            lockedObject.Locked(false);
            if (gotKey)
            {
                lockedObject.Move();
                lockedObject.Locked(true);
            }
        }
    }


    public void Locked(bool isLocked)
    {
        locked = isLocked;
    }
}
