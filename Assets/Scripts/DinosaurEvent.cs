using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinosaurEvent : MonoBehaviour
{
    [SerializeField] GameObject dinosaur;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("DinosaurStart"))
        {
            dinosaur.GetComponent<Animator>().enabled = true;
        }
    }
}
