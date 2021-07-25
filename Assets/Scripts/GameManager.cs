using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool[] completed = new bool[7];
    bool[] collectibleTalampaya = new bool[7];
    bool[] collectibleIschigualasto = new bool[7];
    bool allScenesCompleted = false;
    bool visitedTalampaya = false;
    bool visitedIschigualasto = false;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        completed[1] = true; //Talampaya Canyon is completed be default
    }

    public void LevelCompleted(int levelNumber)
    {
        completed[levelNumber] = true;
        allScenesCompleted = true;
        for (int i = 0; i < completed.Length; i++)
        {
            if (completed[i] == false)
                allScenesCompleted = false;
        }
    }

    public void CollectableFound(int collectableNumber, string objectZone)
    {
        if (objectZone.Equals("Talampaya"))
        {
            collectibleTalampaya[collectableNumber] = true;
        }
        else
        {
            collectibleIschigualasto[collectableNumber] = true;
        }
    }
}
