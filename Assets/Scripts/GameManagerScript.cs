using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject jugador;
    public Light colorLuzMala;
    public GameObject canvas;

    //GameObject ChildGameObject1 = ParentGameObject.transform.GetChild(0).gameObject;
    void Start()
    {
        Application.targetFrameRate = 30;
    }

    // Update is called once per frame
    void Update()
    {
        if (Application.targetFrameRate != 30)
        {
            Application.targetFrameRate = 30;

        }
    }

    void JuegoTerminado()
    {
        colorLuzMala.color = new Color(0.8773585f, 0.352007f, 0.1531239f);
    }

    public bool EstadoJugador()
    {
        if (jugador.GetComponent<Descendify>().gazeTimerUp)
        {
            return true;
        }
        else { return false; }
    }

}
