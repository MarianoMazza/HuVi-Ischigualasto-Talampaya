using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionsScript : InteractableWithSound
{
    [SerializeField] string animationName;
    [SerializeField] QuestionsScript question;
    [SerializeField] GameObject nextQuestion;
    [SerializeField] GameObject answers;
    [SerializeField] int timeToNextQuestion;
    [SerializeField] bool amIFinalQuestion;
    [SerializeField] GameObject finalCollider;

    public override void Interact()
    {
        base.Interact();
        DoAnswer();
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
            finalCollider.SetActive(false);
        }
        answers.SetActive(false);
        this.gameObject.SetActive(false);
    }
}
