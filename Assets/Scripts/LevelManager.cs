using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    int levelNumber;

    [SerializeField]
    int objectivesCount;

    int objectivesTriggered = 0;
    GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void ObjectiveTriggered()
    {
        objectivesTriggered++;
        if (this.objectivesTriggered >= objectivesCount)
        { 
            gameManager.LevelCompleted(levelNumber);
        }
    }

    public int ObjectivesTriggered()
    {
        return this.objectivesTriggered;
    }
}