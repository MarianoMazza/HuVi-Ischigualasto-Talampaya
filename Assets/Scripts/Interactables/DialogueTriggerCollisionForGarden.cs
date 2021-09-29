using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerCollisionForGarden : InteractableWithSound
{
    [SerializeField]
    InteractableWithSound rangerInteractable;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            int objectivesCount = 0;
            foreach (GameObject target in this.GetFox().getTargets())
            {
                if (target.CompareTag("Objective"))
                {
                    objectivesCount++;
                    break;
                }
            }
            if (objectivesCount == 0)
            {
                rangerInteractable.SetDialogue(GetDialogue());
                rangerInteractable.Speak();
                SpawnNextObject();
                DisableThisCollider();
            }
        }
    }
}
