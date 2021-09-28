using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecificAnimations : InteractableWithSound
{
    [SerializeField]
    string animationName;

    [SerializeField]
    GameObject AnimatedObject;

    public override void Interact()
    {
        base.Interact();
        TriggerAnimation(animationName);
    }

    public void TriggerAnimation(string animationName)
    {
        AnimatedObject.GetComponent<Animator>().SetTrigger(animationName);
    }
}
