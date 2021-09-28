using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindEvent : MonoBehaviour
{
    [SerializeField]
    AudioClip windSound;

    [SerializeField]
    AudioSource audioSource;

    [SerializeField]
    ParticleSystem sandstorm;

    [SerializeField]
    FoxController fox;

    Animator playerAnimator;
    bool gotToTheEnd = false;
    const int playerMaximumSpeed = 10;
    const int playerMinimumSpeed = 8;

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
                this.GetComponent<MOVER>().speed = playerMinimumSpeed;
                playerAnimator.SetTrigger("WindSoundOn");
                sandstorm.Play();
                yield return new WaitForSeconds(time);
                playerAnimator.SetTrigger("WindSoundOff");
                this.GetComponent<MOVER>().speed = playerMaximumSpeed;
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
            this.GetComponent<MOVER>().speed = playerMaximumSpeed;
        }
        else if (collision.gameObject.CompareTag("Protection"))
        {
            this.GetComponent<MOVER>().speed = playerMaximumSpeed;
            collision.GetComponent<BoxCollider>().enabled = false;
        }
        else if (collision.gameObject.CompareTag("WindStop"))
        {
            playerAnimator.SetTrigger("WindSoundOff");
            this.GetComponent<MOVER>().speed = playerMaximumSpeed;
            sandstorm.Stop();
            gotToTheEnd = true;
        }
    }
}
