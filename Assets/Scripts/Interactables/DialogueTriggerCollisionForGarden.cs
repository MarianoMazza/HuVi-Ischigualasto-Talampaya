using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerCollisionForGarden : InteractableWithSound
{
    [SerializeField]
    InteractableWithSound guardaparques;
    [SerializeField]
    FoxController fox;
    [SerializeField]
    int maxFoxObjectivesForTrigger = 1;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (fox.getTargets().Count <= maxFoxObjectivesForTrigger)
            {
                guardaparques.SetDialogue(GetDialogue());
                guardaparques.Speak();
                SpawnNextObject();
            }
        }
    }
}
