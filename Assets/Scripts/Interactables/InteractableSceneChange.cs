using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractableSceneChange : Interactable
{
    [SerializeField]
    string sceneName;

    [SerializeField]
    string park;

    [SerializeField]
    bool finalLevel;

    GameManager gameManager;

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
        else
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
