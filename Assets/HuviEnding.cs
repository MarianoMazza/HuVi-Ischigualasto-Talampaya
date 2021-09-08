using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HuviEnding : Interactable
{
    [SerializeField]
    int timeToAnimateNext;
    const string gameBeginning = "Beginning";
    [SerializeField] AudioClip[] dialogues;
    [SerializeField] AudioSource audioSource;
    int presentDialogue = 0;
    GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    public override void Interact()
    {
        Speak();
        StartCoroutine(AfterPlayed(audioSource));
        DisableThisCollider();
    }
    IEnumerator GoToNextScene(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(gameBeginning);
    }

    public void Speak()
    {
        audioSource.clip = dialogues[presentDialogue];
        audioSource.Play();
    }

    IEnumerator AfterPlayed(AudioSource audioSource)
    {
        yield return new WaitWhile(() => audioSource.isPlaying);
        if (gameManager.GetAllObjectivesAchieved())
        {
            presentDialogue = 1;
        }
        else
        {
            presentDialogue = 2;
        }
        Speak();
        StartCoroutine(GoToNextScene(15));
    }

    public void DisableThisCollider()
    {
        gameObject.GetComponent<Collider>().enabled = false;
    }
}
