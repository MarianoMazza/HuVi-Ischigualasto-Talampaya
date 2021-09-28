using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionDetection : MonoBehaviour
{
    [SerializeField]
    GameObject guardaparques;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("WindStart"))
        {
            
        }
    }
}
