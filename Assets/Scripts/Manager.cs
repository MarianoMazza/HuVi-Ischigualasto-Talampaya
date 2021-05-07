using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    [SerializeField] FoxController foxController;
    [SerializeField] GameObject objectToFollow;

    void Start()
    {
        foxController.GoToObject(objectToFollow.gameObject.transform.position, "Walk");
    }


    void Update()
    {
        
    }

}
