using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableCollectable : InteractableWithSound
{
    [Header("Collectable Settings")]
    [SerializeField] int objectNumber;
    [SerializeField] string objectZone;
    GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public override void Interact()
    {
        base.Interact();
        gameManager.CollectableFound(objectNumber,objectZone);
    }
}
