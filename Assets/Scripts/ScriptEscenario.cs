using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptEscenario : MonoBehaviour
{

    public Material cielo;
    public GameObject luzMala, sol;
    // Start is called before the first frame update
    void Start()
    {
        RenderSettings.skybox = cielo;
        if (luzMala != null) {
            sol.SetActive(false);
            luzMala.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
