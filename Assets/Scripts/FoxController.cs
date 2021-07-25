using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class FoxController : Interactable
{
    float speed = 7.0f;
    [SerializeField]
    float walkingSpeed = 3;
    [SerializeField]
    float runningSpeed = 7;
    float step;
    [SerializeField] List<GameObject> targets;
    Vector3 currentTarget;
    string animationName = "Sit";
    bool forceRun;
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
            else if (targets[0].gameObject.CompareTag("RouteReference"))
            {
                this.RemoveCurrentTarget();
                currentTarget = targets[0].transform.position;
                CalculateDistanceToObject();
            }
            else if (!this.GetComponent<Animator>().GetBool("Stand"))
            {
                this.GetComponent<Animator>().SetTrigger("Stand");
            }
            if ((currentTarget.x != targets[0].transform.position.x) || currentTarget.z != targets[0].transform.position.z)
            {
                currentTarget = targets[0].transform.position;
                CalculateDistanceToObject();
            }
        }
    }

    public void ObjectSeen(GameObject seenObject)
    {
        if (seenObject != this.gameObject)
        {
            targets.Remove(seenObject);
            if (targets.Count > 0)
                currentTarget = targets[0].transform.position;
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
        if (!forceRun)
        {
            this.GetComponent<Animator>().ResetTrigger("Stand");
            if (!sitting)
            {
                if (Vector3.Distance(currentTarget, gameObject.transform.position) < 50)
                {
                    speed = walkingSpeed;
                }
                else
                    speed = runningSpeed;
                if (speed <= walkingSpeed)
                    animationName = "Walk";
                else
                    animationName = "Run";
            }
            this.GetComponent<Animator>().SetTrigger(animationName);
        }
        else
            forceRun = false;
    }

    public void RemoveCurrentTarget()
    {
        targets.Remove(targets[0]);
    }

    public void Run()
    {
        forceRun = true;
        speed = runningSpeed;
        animationName = "Run";
        this.GetComponent<Animator>().SetTrigger(animationName);
    }
}
