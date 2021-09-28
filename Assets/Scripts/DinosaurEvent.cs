using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinosaurEvent : MonoBehaviour
{
    [SerializeField]
    GameObject leg;

    [SerializeField]
    GameObject arm;

    [SerializeField]
    GameObject skull;

    [SerializeField]
    GameObject player;

    [SerializeField]
    AudioSource audioSource;

    [SerializeField]
    FoxController fox;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("DinosaurStart"))
        {
            leg.GetComponent<Animator>().enabled = true;
            skull.GetComponent<Animator>().enabled = true;
            arm.GetComponent<Animator>().enabled = true;
            audioSource.Play();
            player.GetComponent<Animator>().SetTrigger("WindSoundOn");
            StartCoroutine(WaitThisTime(5));
            fox.ObjectSeen(collision.gameObject);
        }
    }

    IEnumerator WaitThisTime(float time)
    {
        yield return new WaitForSeconds(time);
        player.GetComponent<Animator>().SetTrigger("WindSoundOff");
        yield return new WaitForSeconds(time);
        audioSource.Stop();
    }

}
