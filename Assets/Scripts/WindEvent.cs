using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindEvent : MonoBehaviour
{
    [SerializeField] AudioClip windSound;
    [SerializeField] AudioSource audioSource;
    [SerializeField] ParticleSystem sandstorm;
    Animator playerAnimator;
    [SerializeField] FoxController fox;
    bool gotToTheEnd = false;

    private void Start()
    {
        playerAnimator = this.GetComponent<Animator>();
        sandstorm.Stop();
    }

    IEnumerator RandomWindTiming(float time)
    {
        yield return new WaitForSeconds(time);
        if (!gotToTheEnd)
        {
            if (Random.Range(0, 100) < 50)
            {
                this.GetComponent<MOVER>().speed = 4;
                playerAnimator.SetTrigger("WindSoundOn");
                sandstorm.Play();
                yield return new WaitForSeconds(time);
                playerAnimator.SetTrigger("WindSoundOff");
                this.GetComponent<MOVER>().speed = 13;
                sandstorm.Stop();
            }
            StartCoroutine(RandomWindTiming(time));
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("WindStart"))
        {
            StartCoroutine(RandomWindTiming(10));
            audioSource.Play();
            fox.ObjectSeen(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Protection"))
        {
            this.GetComponent<MOVER>().speed = 13;
            collision.GetComponent<BoxCollider>().enabled = false;
        }
        else if (collision.gameObject.CompareTag("WindStop"))
        {
            playerAnimator.SetTrigger("WindSoundOff");
            this.GetComponent<MOVER>().speed = 13;
            sandstorm.Stop();
            gotToTheEnd = true;
        }
    }
}
