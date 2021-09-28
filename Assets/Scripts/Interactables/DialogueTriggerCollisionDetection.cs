using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerCollisionDetection : InteractableWithSound
{
    [SerializeField]
    InteractableWithSound ranger;
 
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ranger.SetDialogue(this.GetDialogue());
            ranger.Speak();
            SpawnNextObject();
            RepositionRanger();
            DisableThisCollider();
        }
    }
}
