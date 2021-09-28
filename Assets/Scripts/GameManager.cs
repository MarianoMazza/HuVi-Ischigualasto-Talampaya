using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    bool visitedTalampaya = false;

    [SerializeField]
    bool visitedIschigualasto = false;

    bool[] completed = new bool[7];
    bool[] collectiblesTalampaya = new bool[5];
    bool[] collectiblesIschigualasto = new bool[5];
    bool allObjectivesAchieved = false;
    CollectiblesSign collectiblesSign;
    const string videoTalampaya = "360Talampaya";
    const string videoIschigualasto = "360Ischigualasto";

    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(_instance.gameObject);
        }
        _instance = this;
        DontDestroyOnLoad(this.gameObject);
        completed[1] = true; //Talampaya Canyon is completed by default  
    }

    public void LevelCompleted(int levelNumber)
    {
        completed[levelNumber] = true;
        allObjectivesAchieved = true;
        for (int i = 0; i < completed.Length; i++)
        {
            if (completed[i] == false)
            {
                allObjectivesAchieved = false;
            }
        }
    }

    public bool GetAllObjectivesAchieved()
    {
        return allObjectivesAchieved;
    }

    public void ParkCompleted(string parkName)
    {
        if (parkName.Equals("Talampaya"))
        {
            visitedTalampaya = true;
            SceneManager.LoadScene(videoTalampaya);
        }
        else
        {
            visitedIschigualasto = true;
            SceneManager.LoadScene(videoIschigualasto);
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
