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
        RepositionRanger();

        Speak();

        if (gameObject.GetComponent<Animator>())
            gameObject.GetComponent<Animator>().enabled = true;

        StartCoroutine(MoveFoxAfterTime(timeToAnimateNext));

        if (forceRunFox)
            fox.Run();

        SpawnNextObject();
    }

    public void RepositionRanger()
    {
        if (rangerPosition != null && ranger != null)
        {
            ranger.transform.position = new Vector3(rangerPosition.transform.position.x, ranger.transform.position.y, rangerPosition.transform.position.z);
            ranger.transform.forward = new Vector3(rangerPosition.transform.forward.x, ranger.transform.forward.y, rangerPosition.transform.forward.z);
        }
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

    IEnumerator MoveFoxAfterTime(float time)
    {
        if (forceMoveFox)
        {
            yield return new WaitForSeconds(time);
            fox.RemoveCurrentTarget();
        }
    }

    public void AnimateNextObject()
    {
        nextObject.GetComponent<Animator>().enabled = true;
    }

    public void Speak()
    {
        if (dialogue != null)
        {
            audioSource.clip = dialogue;
        }
        audioSource.Play();
    }

    public void SetDialogue(AudioClip _dialogue)
    {
        dialogue = _dialogue;
    }

    public AudioClip GetDialogue()
    {
        return dialogue;
    }
}
