using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectiblesSign : MonoBehaviour
{
    GameManager gameManager;
    public string zoneName;
    [SerializeField] 
    GameObject[] collectibles = new GameObject[5];

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        gameManager.ReceiveCollectiblesSign(this);
    }

    public void ReceiveFoundCollectables(bool[] foundCollectibles)
    {
        for (int i = 0; i < foundCollectibles.Length; i++)
        {
            if (foundCollectibles[i])
            {
                collectibles[i].SetActive(true);
            }
        }
    }
}
