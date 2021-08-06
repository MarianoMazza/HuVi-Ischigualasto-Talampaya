using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool[] completed = new bool[7];
    bool[] collectiblesTalampaya = new bool[5];
    bool[] collectiblesIschigualasto = new bool[5];
    bool allScenesCompleted = false;
    [SerializeField]
    bool visitedTalampaya = false;
    [SerializeField]
    bool visitedIschigualasto = false;
    CollectiblesSign collectiblesSign;

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

    public void ParkCompleted(string parkName)
    {
        if (parkName.Equals("Talampaya"))
        {
            visitedTalampaya = true;
        }
        else
        {
            visitedIschigualasto = true;
        }
    }
    
    public bool VisitedBothParks()
    {
        return (visitedTalampaya && visitedIschigualasto);
    }

    public void CollectableFound(int collectableNumber, string objectZone)
    {
        if (collectiblesSign.zoneName.Equals("Talampaya"))
        {
            collectiblesTalampaya[collectableNumber] = true;
            collectiblesSign.ReceiveFoundCollectables(collectiblesTalampaya);
        }
        else
        {
            collectiblesIschigualasto[collectableNumber] = true;
            collectiblesSign.ReceiveFoundCollectables(collectiblesIschigualasto);
        }
    }

    public void ReceiveCollectiblesSign(CollectiblesSign _collectiblesSign)
    {
        collectiblesSign = _collectiblesSign;
        if (collectiblesSign.zoneName.Equals("Talampaya"))
        {
            collectiblesSign.ReceiveFoundCollectables(collectiblesTalampaya);
        }
        else
        {
            collectiblesSign.ReceiveFoundCollectables(collectiblesIschigualasto);
        }
    }
}
