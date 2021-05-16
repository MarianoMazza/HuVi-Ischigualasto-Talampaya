using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxController : Interactable
{
    float speed = 6.0f;
    float step;
    [SerializeField] List<GameObject> targets;
    Vector3 currentTarget;
    string animationName = "Sit";
    bool roam;
    [SerializeField] bool sitting;
    private void Start()
    {
        currentTarget = targets[0].transform.position;
        CalculateDistanceToObject();

    }

    void Update()
    {
        if (!sitting)
        {
            if (Vector3.Distance(currentTarget, gameObject.transform.position) > 3)
            {
                step = speed * Time.deltaTime;
                currentTarget.y = transform.position.y;

                Vector3 newPosition = Vector3.MoveTowards(transform.position, currentTarget, step);
                transform.position = newPosition;

                Vector3 newDirection = Vector3.RotateTowards(transform.forward, currentTarget - transform.position, 0.03f, 100f);
                transform.rotation = Quaternion.LookRotation(newDirection);
            }
            else if (!this.GetComponent<Animator>().GetBool("Stand"))
            {
                this.GetComponent<Animator>().SetTrigger("Stand");
            }
        }
    }

    public void ObjectSeen(GameObject seenObject)
    {
        if (seenObject != this.gameObject)
        {
            targets.Remove(seenObject);
            if(targets.Count > 0) currentTarget = targets[0].transform.position;
        }
        CalculateDistanceToObject();
    }

    public override void Interact()
    {
        if (!sitting)
        {
            animationName = "Sit";
            sitting = true;
        }
        else
        {
            this.GetComponent<Animator>().ResetTrigger("Sit");
            sitting = false;
        }
    }

    public void CalculateDistanceToObject()
    {
        this.GetComponent<Animator>().ResetTrigger("Stand");
        if (!sitting)
        {
            if (Vector3.Distance(currentTarget, gameObject.transform.position) < 50)
            {
                speed = 3;
            }
            else speed = 6;
            if (speed <= 3) animationName = "Walk";
            else animationName = "Run";
        }
        this.GetComponent<Animator>().SetTrigger(animationName);
    }
}
