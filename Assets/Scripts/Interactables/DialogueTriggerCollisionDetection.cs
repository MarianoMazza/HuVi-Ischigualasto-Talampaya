using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerCollisionDetection : InteractableWithSound
{
    [SerializeField]
    InteractableWithSound guardaparques;
 
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            guardaparques.SetDialogue(this.GetDialogue());
            guardaparques.Speak();
            SpawnNextObject();
            RepositionRanger();
        }
    }
}
