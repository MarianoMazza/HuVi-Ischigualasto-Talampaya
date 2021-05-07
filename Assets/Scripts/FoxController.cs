using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxController : MonoBehaviour
{
    float speed = 1.0f;
    float step;
    Vector3 targetPosition;
    string animationName;

    public void GoToObject(Vector3 targetPosition, string animationName)
    {
        this.targetPosition = targetPosition;
        this.GetComponent<Animator>().SetTrigger("Walk");
        if (animationName == "Walk") speed = 3.0f;
        else speed = 6.0f;
        //en vez de lo anterior sencillamente triggerear la animacion
    }

    void Update()
    {
        if (targetPosition.x != transform.position.x && targetPosition.z != transform.position.z)
        {
            step = speed * Time.deltaTime;
            targetPosition.y = transform.position.y;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
        }
        else if (!this.GetComponent<Animator>().GetBool("Stand")) {
            this.GetComponent<Animator>().SetTrigger("Stand");
        }
    }
}
