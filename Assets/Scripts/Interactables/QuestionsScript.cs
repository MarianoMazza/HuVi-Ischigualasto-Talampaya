using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionsScript : InteractableWithSound
{
    [SerializeField] string animationName;
    [SerializeField] QuestionsScript question;
    [SerializeField] GameObject nextQuestion;
    [SerializeField] GameObject answers;

    public override void Interact()
    {
        base.Interact();
        DoAnswer();
    }

    public void DoAnswer()
    {
        if (question != null)
        {
            StartCoroutine(question.NextQuestion());
        }
    }

    public IEnumerator NextQuestion()
    {
        if (nextQuestion != null)
        {
            yield return new WaitForSeconds(5);
            nextQuestion.SetActive(true);
        }
        answers.SetActive(false);
        this.gameObject.SetActive(false);
    }
}
