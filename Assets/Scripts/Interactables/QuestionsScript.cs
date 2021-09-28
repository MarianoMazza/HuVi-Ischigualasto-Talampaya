using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionsScript : InteractableWithSound
{
    [SerializeField]
    string animationName;

    [SerializeField]
    QuestionsScript question;

    [SerializeField]
    GameObject nextQuestion;

    [SerializeField]
    GameObject answers;

    [SerializeField]
    int timeToNextQuestion;

    [SerializeField]
    bool amIFinalQuestion;

    [SerializeField]
    GameObject finalCollider;

    [SerializeField]
    AudioClip dialogueIfLastQuestion;


    public override void Interact()
    {
        base.Interact();
        if (question != null)
        {
            DoAnswer();
        }
    }

    public void DoAnswer()
    {
        StartCoroutine(question.NextQuestion());
    }

    public IEnumerator NextQuestion()
    {
        yield return new WaitForSeconds(timeToNextQuestion);
        if (nextQuestion != null)
        {
            nextQuestion.SetActive(true);
        }
        else
        {
           StartCoroutine(AfterPlayed(this.GetAudioSource()));
        }
        StartCoroutine(DeactivateAnswers(this.GetAudioSource()));
    }

    IEnumerator AfterPlayed(AudioSource audioSource)
    {
        answers.SetActive(false);
        yield return new WaitWhile(() => audioSource.isPlaying);
        this.SetDialogue(dialogueIfLastQuestion);
        this.Speak();
        finalCollider.SetActive(false);
    }

    IEnumerator DeactivateAnswers(AudioSource audioSource)
    {
        yield return new WaitWhile(() => audioSource.isPlaying);
        this.gameObject.SetActive(false);
    }
}
