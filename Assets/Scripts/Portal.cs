using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public float x, y, z;
    public GameObject salaSiguiente;
    public GameObject salaAnterior;
    public GameObject sol;
    public GameObject luzMala;
    public bool desactivarSol;
    public bool desactivarLuzMala;
    public GameObject siguientePortal;
    public string fraseFaltaAlgo;
    public string fraseFinal;
    public bool seleccionado = false;
    public Quaternion rotacionCamara;
    public Quaternion rotacionRobot;
    public Material cielo;
    public bool posicionarObjeto = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public Vector3 PosicionTeletransportacion() {
        return new Vector3(x, y, z);
    }

    public void ActivarSala() {
        if (!salaSiguiente.activeSelf)
        {
            salaSiguiente.SetActive(true);
        }
        if (salaAnterior.activeSelf)
        {
            salaAnterior.SetActive(false);
        }

        if (desactivarSol)
        {
            sol.SetActive(false);
        }
        else
        {
            sol.SetActive(true);
        }

        if (desactivarLuzMala)
        {
            luzMala.SetActive(false);
        }
        else
        {
            luzMala.SetActive(true);
        }
        RenderSettings.skybox = cielo;

    }

    public Quaternion rotacionSiguientePortal() {
        return siguientePortal.transform.rotation;
    }

    public string FraseActual()
    {
        if (!seleccionado)
        {
            return fraseFaltaAlgo;
        }
        else
        {
            return fraseFinal;
        }
    }

    public Quaternion RotacionCamara()
    {
        return rotacionCamara;
    }
    public Quaternion RotacionRobot()
    {
        return rotacionRobot;
    }
}
