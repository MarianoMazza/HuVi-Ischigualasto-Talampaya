using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VideoManager : MonoBehaviour
{
    GameManager gameManager;
    const string gameEnding = "Ending";
    [SerializeField]
    string sceneName;
    [SerializeField]
    int timeToNextScene;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        StartCoroutine(GoToNextScene(timeToNextScene));
    }

    IEnumerator GoToNextScene(float time)
    {
        yield return new WaitForSeconds(time);
        if (gameManager.VisitedBothParks())
        {
            SceneManager.LoadScene(gameEnding);
        }
        else
        {
            SceneManager.LoadScene(sceneName);
        }
    }

    public void ForceGoToNextScene() {
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
