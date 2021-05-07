using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoSeleccionado : MonoBehaviour
{
    // Start is called before the first frame update
    public bool seleccionado = false;
    public bool activarFraseExtra = false;
    public string fraseFaltaAlgo;
    public string fraseFinal;
    public string fraseExtra;
    public Descendify jugador;
    public bool condicion = false;
    public GameObject ojoVisto;
    public bool tengoOjo = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Seleccion()
    {
        seleccionado = true;
    }
    public void TerminarSeleccion()
    {
        seleccionado = false;
    }

    public bool EstadoSeleccionado() {
        return seleccionado;
    }

    public string FraseActual() {
        if (tengoOjo) { 
        ojoVisto.SetActive(true);
        }
        if (activarFraseExtra) {
            return fraseExtra;
        }
        else if (!seleccionado)
        {
            return fraseFaltaAlgo;
        }
        else {
            return fraseFinal;
        }
    }

    public void FuiSeleccionado() {
        jugador.RecibirReferenciado(this);
    }

    public bool EstadoCondicion() {
        return condicion;
    }

    public void CambiarCondicion() {
        condicion = !condicion;
    }
}
