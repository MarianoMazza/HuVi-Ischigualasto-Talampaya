using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggerearsonido : MonoBehaviour
{
    bool once = false;

    public GameObject cristal5, cristal2, cristal3, cristal4, cristal8, cristal6, cristal7;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        // if (!once) {
        //  this.GetComponent<Renderer>().material.color = new Color(0, 185, 250, 3);
        //this.GetComponent<Renderer>().material.SetColor("_Color", new Color(0, 185, 250));
        //  once = true;
        // }
    }

    public void EsMirado()
    {
        if (this.GetComponent<Light>().enabled)
        {
            // this.GetComponent<Renderer>().material.SetColor("_Color", new Color(0, 185, 250));
            this.GetComponent<AudioSource>().enabled = true;
            this.GetComponent<AudioSource>().Play();
        }
    }

    public void Encender()
    {
        if (!this.GetComponent<Light>().enabled)
        {
            this.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Vector4(0.0003638174f, 0.0006f, 0.0007f, 0) * 950);
            this.GetComponent<Light>().enabled = true;
            //Debug.Log("Hola");
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            this.Encender();
            cristal2.GetComponent<Triggerearsonido>().Encender();
            cristal3.GetComponent<Triggerearsonido>().Encender();
            cristal4.GetComponent<Triggerearsonido>().Encender();
            cristal5.GetComponent<Triggerearsonido>().Encender();
            cristal6.GetComponent<Triggerearsonido>().Encender();
            cristal7.GetComponent<Triggerearsonido>().Encender();
            cristal8.GetComponent<Triggerearsonido>().Encender();
        }
    }
}
