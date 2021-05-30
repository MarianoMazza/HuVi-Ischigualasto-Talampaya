using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractableSceneChange : Interactable
{
    [SerializeField] string sceneName;
    public override void Interact()
    {
        SceneManager.LoadScene(sceneName);
    }
}
