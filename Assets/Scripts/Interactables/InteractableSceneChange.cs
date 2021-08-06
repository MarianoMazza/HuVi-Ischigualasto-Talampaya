using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractableSceneChange : Interactable
{
    [SerializeField] string sceneName;
    [SerializeField] string park;
    [SerializeField] bool finalLevel;
    GameManager gameManager;
    const string gameEnding = "HuviEnding";

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    public override void Interact()
    {
        if (finalLevel)
        {
            gameManager.ParkCompleted(park);
        }
        if (gameManager.VisitedBothParks())
        {
            SceneManager.LoadScene(gameEnding);
        }
        else
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
