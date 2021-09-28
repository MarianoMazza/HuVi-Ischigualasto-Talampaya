using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gaze : MonoBehaviour
{
    public Animator animacion;
    public float myTime = 0f;
    public Transform radialPorgress;
    public bool gazeTimerUp = false;
    public GameObject text;
    Interactable seenObject;
    int interactableLayer = 8;
    [SerializeField] FoxController fox;
    [SerializeField] LevelManager levelManager;

    void Start()
    {
        animacion = GetComponent<Animator>();
        radialPorgress.GetComponent<Image>().fillAmount = myTime;
    }

    void Update()
    {
        myTime += Time.deltaTime;
        radialPorgress.GetComponent<Image>().fillAmount = myTime / 2;
        if (myTime >= 2f && !gazeTimerUp)
        {
            Interact();
        }
    }

    void OnEnable()
    {
        this.gameObject.GetComponent<MOVER>().enabled = false;
    }

    public void resetCounter()
    {
        gazeTimerUp = false;
        myTime = 0f;
        radialPorgress.GetComponent<Image>().fillAmount = myTime;
        this.gameObject.GetComponent<MOVER>().enabled = true;
    }

    public void Interact()
    {
        gazeTimerUp = true;

        if (seenObject.gameObject.layer == interactableLayer)
        {
            if (seenObject.CompareTag("Objective"))
                levelManager.ObjectiveTriggered();

            seenObject.Interact();
            fox.ObjectSeen(seenObject.gameObject);
        }
        this.resetCounter();
        this.enabled = false;
    }

    public void ObjectSeen(Interactable selectedInteractable)
    {
        seenObject = selectedInteractable;
    }
}
