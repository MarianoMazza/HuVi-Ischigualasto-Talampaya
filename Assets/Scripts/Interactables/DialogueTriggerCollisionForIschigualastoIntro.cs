using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerCollisionForIschigualastoIntro : InteractableWithSound
{
    [SerializeField]
    InteractableWithSound ranger;

    [SerializeField]
    FoxController fox;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (fox.getTargets().Count <= 1)
            {
                ranger.SetDialogue(GetDialogue());
                ranger.Speak();
                SpawnNextObject();
            }
        }
    }
}
