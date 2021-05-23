using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableWithSound : Interactable
{
    //[SerializeField] AudioClip[] speech;
    //[SerializeField] AudioClip speech;
    [SerializeField] AudioSource audioSource;
    //string currentAudio;

    public override void Interact()
    {
        Speak();
        if (gameObject.GetComponent<Animator>())
        {
            gameObject.GetComponent<Animator>().enabled = true;
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

    public void Speak()
    {
        //Convert the string to the audioClip index

        //int audioIndex = FindAudio(currentAudio);

        // if (audioIndex != -1)
        // {

        //Assign the clip to play
        //audioSource.clip = speech;

        //Play
        audioSource.Play();

        // }

    }
}
