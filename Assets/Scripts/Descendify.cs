using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Descendify : MonoBehaviour
{
    public Animator animacion;
    public float myTime = 0f;
    public Transform radialPorgress;
    public LevantarObjetos levantarObjetos;
    public bool gazeTimerUp =false;
    public GameObject text;
    ObjetoSeleccionado objetoObservado;
    bool robotHablando = false;

    void Start()
    {
        animacion = GetComponent<Animator>();
        radialPorgress.GetComponent<Image>().fillAmount = myTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (!robotHablando) { 
        myTime += Time.deltaTime;
        radialPorgress.GetComponent<Image>().fillAmount = myTime/2;
        if (myTime >= 2f && !gazeTimerUp)
        {
            levantarObjetos.selectedObject = objetoObservado;
            changeSpot();
            levantarObjetos.AnimarRobot();
        }
        }
    }

    public void RobotHabla() {
        robotHablando = !robotHablando;
    }
    public void resetCounter()
    {
        gazeTimerUp = false;
        myTime = 0f;
        radialPorgress.GetComponent<Image>().fillAmount = myTime;
    }
    public void changeSpot()
    {
        gazeTimerUp = true;
        if (objetoObservado.gameObject.name == "Portal")
        {
            if (!objetoObservado.GetComponent<Portal>().posicionarObjeto) { 
            levantarObjetos.SoltarEnPortales();
            }
            levantarObjetos.PasarPortal();
        }
        else { 
        if (!levantarObjetos.carrying)
        {
            levantarObjetos.pickup();
        }
            else {
                    if(objetoObservado.tag == "Objetivo" || objetoObservado.tag == "ComputadoraHopper") { 
                levantarObjetos.Seleccionarlo();
                levantarObjetos.dropObject();
                    }
                    else { levantarObjetos.pickup(); }
            }
        }
    }

    public void RecibirReferenciado(ObjetoSeleccionado objSeleccionado)
    {
        objetoObservado = objSeleccionado;
    }
}
