using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableWithSound : Interactable
{
    //[SerializeField] AudioClip[] speech;
    [SerializeField] AudioClip dialogue;
    [SerializeField] AudioSource audioSource;
    [SerializeField] GameObject nextObject;
    [SerializeField] bool activateNextAnimation;
    [SerializeField] float timeToAnimateNext;
    [SerializeField] GameObject rangerPosition;
    [SerializeField] GameObject ranger;

    [Header("Fox Settings")]
    [SerializeField] bool forceMoveFox;
    [SerializeField] bool forceRunFox;
    [SerializeField] FoxController fox;
    //string currentAudio;

    public override void Interact()
    {
        if (rangerPosition != null)
            ranger.transform.position = rangerPosition.transform.position;

        Speak();

        if (gameObject.GetComponent<Animator>())
            gameObject.GetComponent<Animator>().enabled = true;

        if (forceMoveFox)
            fox.RemoveCurrentTarget();

        if (forceRunFox)
            fox.Run();

        SpawnNextObject();
    }

    /* public int FindAudio(string audioName)
     {
         for (int i = 0; i < speech.Length; i++)
         {
             if (speech[i].name == audioName)
             {
                 return i;
             }
         }
         return -1;
     }*/

    public void SpawnNextObject()
    {
        if (nextObject != null)
        {
            nextObject.SetActive(true);
            if (nextObject.GetComponent<Animator>() && activateNextAnimation)
                StartCoroutine(AnimateAfterTime(timeToAnimateNext));

        }
    }
    IEnumerator AnimateAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        nextObject.GetComponent<Animator>().enabled = true;
    }

    public void AnimateNextObject()
    {
        nextObject.GetComponent<Animator>().enabled = true;
    }

    public void Speak()
    {
        //Convert the string to the audioClip index

        //int audioIndex = FindAudio(currentAudio);

        // if (audioIndex != -1)
        // {

        //Assign the clip to play
        if(audioSource.gameObject != this.gameObject)
            audioSource.clip = dialogue;

        //Play
        audioSource.Play();

        // }

    }
}
