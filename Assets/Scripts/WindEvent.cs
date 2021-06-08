using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindEvent : MonoBehaviour
{
    [SerializeField] AudioClip windSound;
    [SerializeField] AudioSource audioSource;

    IEnumerator RandomWindTiming(float time)
    {
        yield return new WaitForSeconds(time);

        if (Random.Range(0, 100) < 50)
        {
            this.GetComponent<MOVER>().speed = 4;
            audioSource.Play();
            yield return new WaitForSeconds(time);
            audioSource.Stop();
            this.GetComponent<MOVER>().speed = 9;
        }

        StartCoroutine(RandomWindTiming(time));

    }


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("WindStart"))
        {
            StartCoroutine(RandomWindTiming(5));
        }
        else if(collision.gameObject.CompareTag("Protection"))
        {
            this.GetComponent<MOVER>().speed = 9;
        }
    }
}
