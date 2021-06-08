using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuseumManager : MonoBehaviour
{
    [SerializeField] GameObject light1, light2, light3;
    [SerializeField] AudioClip dialogue;
    [SerializeField] AudioSource audioSource;
    [SerializeField] GameObject sign;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (light1.activeSelf && light2.activeSelf && light3.activeSelf) 
        {
            audioSource.clip = dialogue;
            audioSource.Play();
            sign.SetActive(true);
        }
    }
}
