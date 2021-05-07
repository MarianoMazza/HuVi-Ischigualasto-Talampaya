using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonFinal : MonoBehaviour
{
    public GameObject recompensa;
    public GameManagerScript manager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AnimacionFinal()
    {

            GetComponent<ObjetoSeleccionado>().TerminarSeleccion();


        recompensa.GetComponent<Animator>().SetTrigger("AnimacionFinal");

    }
}
