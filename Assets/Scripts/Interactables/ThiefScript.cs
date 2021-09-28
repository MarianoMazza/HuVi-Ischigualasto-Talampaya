using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThiefScript : InteractableWithSound
{
    [SerializeField] string animationName;
    [SerializeField] GameObject thief;

    public override void Interact()
    {
        base.Interact();
        SetThiefAnimation(animationName);
    }

    public void SetThiefAnimation(string animationName)
    {
        thief.GetComponent<Animator>().SetTrigger(animationName);
    }
}
