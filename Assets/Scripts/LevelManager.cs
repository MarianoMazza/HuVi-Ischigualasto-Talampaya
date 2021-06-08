using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] int levelNumber;
    [SerializeField] int objectivesCount;
    private int objectivesTriggered = 0;
    [SerializeField] GameManager gameManager;

    public void ObjectiveTriggered()
    {
        objectivesTriggered++;
        if (this.objectivesTriggered >= objectivesCount)
            gameManager.LevelCompleted(levelNumber);
    }
}