using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractablePickUp : Interactable
{
    [SerializeField]
    GameObject hand;

    [SerializeField]
    GameObject PetroglyphTable;

    Vector3 startingPosition;
    Quaternion startingRotation;
    Vector3 startingScale;

    private void Start()
    {
        startingPosition = transform.localPosition;
        startingScale = transform.localScale;
        startingRotation = transform.localRotation;
    }

    public override void Interact()
    {
        if (hand.transform.childCount > 0)
        {
            GameObject ChildGameObject0 = hand.transform.GetChild(0).gameObject;
            if (this.CompareTag("SignPosition"))
            {
                ChildGameObject0.transform.parent = this.transform.parent.transform;
                ChildGameObject0.transform.localRotation = new Quaternion(0, 0, 0, 0);
                ChildGameObject0.transform.localScale = this.transform.localScale;
                Vector3 newPosition = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y - 0.12f, this.transform.localPosition.z);
                ChildGameObject0.transform.localPosition = newPosition;
            }
            else
            {
                ChildGameObject0.transform.parent = PetroglyphTable.transform;
                ChildGameObject0.transform.localPosition = startingPosition;
                ChildGameObject0.transform.localRotation = startingRotation;
                ChildGameObject0.transform.localScale = startingScale;
                transform.parent = hand.transform;
                transform.localPosition = new Vector3(0, 0, 0);
            }
        }
        else if (!this.CompareTag("SignPosition"))
        {
            transform.parent = hand.transform;
            transform.localPosition = new Vector3(0, 0, 0);
        }
    }

}
