using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThiefEvent : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("ThiefStart"))
        {
            collision.gameObject.GetComponent<Interactable>().Interact();
        }
    }
}
