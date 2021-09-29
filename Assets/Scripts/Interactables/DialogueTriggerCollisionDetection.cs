using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerCollisionDetection : InteractableWithSound
{
    [SerializeField]
    InteractableWithSound rangerInteractable;
 
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            rangerInteractable.SetDialogue(this.GetDialogue());
            rangerInteractable.Speak();
            SpawnNextObject();
            RepositionRanger();
            DisableThisCollider();
        }
    }
}
