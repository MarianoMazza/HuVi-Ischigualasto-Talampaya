using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuseumManager : MonoBehaviour
{
    [SerializeField]
    GameObject light1, light2, light3;

    [SerializeField]
    AudioClip dialogue;

    [SerializeField]
    AudioSource audioSource;

    [SerializeField]
    GameObject sign;

    [SerializeField]
    GameObject dinosaurCollider;

    void Update()
    {
        if (light1.activeSelf && light2.activeSelf && light3.activeSelf) 
        {
            sign.SetActive(true);
            dinosaurCollider.SetActive(true);
        }
    }
}
