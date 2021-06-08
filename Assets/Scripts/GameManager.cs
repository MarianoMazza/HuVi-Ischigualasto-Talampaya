using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int objectivesCount;
    List<GameObject> objectives;
    bool[] completed = new bool[7];
    bool allScenesCompleted = false;
    bool visitedTalampaya = false;
    bool visitedIschigualasto = false;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void SetObjectivesCount(int objectivesCount)
    {
        objectives.Clear();
        this.objectivesCount = objectivesCount;
    }

    public void LevelCompleted(int levelNumber) 
    {
        completed[levelNumber] = true;
        allScenesCompleted = true;
        for (int i = 0; i < completed.Length; i++) {
            if(completed[i] == false)
                allScenesCompleted = false;
        }
    }
}
