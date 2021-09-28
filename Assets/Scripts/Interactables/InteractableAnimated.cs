using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableAnimated : Interactable
{
    public override void Interact()
    {
        gameObject.GetComponent<Animator>().enabled = true;
    }
}
