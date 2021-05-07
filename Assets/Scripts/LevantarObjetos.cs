using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevantarObjetos : MonoBehaviour
{
    GameObject mainCamera;
    public bool carrying;
    GameObject carriedObject;
    public float distance;
    public float smooth;
    public ObjetoSeleccionado selectedObject { get; set; }
    public float x, y, z;
    public GameManagerScript manager;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.FindWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {

        if (carrying)
        {
            carry(carriedObject);
            checkDrop();
        }

    }
    public void PasarPortal()
    {
        this.gameObject.GetComponent<DemoPlayerController>().enabled = false;
        this.gameObject.GetComponent<MOVER>().enabled = false;
        this.gameObject.GetComponent<Descendify>().resetCounter();
        this.gameObject.GetComponent<Descendify>().enabled = false;
        selectedObject.gameObject.GetComponent<Portal>().ActivarSala();
        transform.position = selectedObject.gameObject.GetComponent<Portal>().PosicionTeletransportacion();

        StartCoroutine("DoCheck");
    }

    public void AsignarCarried(GameObject objeto)
    {
        carriedObject = objeto;
    }
    void rotateObject()
    {
        carriedObject.transform.Rotate(5, 10, 15);
    }

    void carry(GameObject o)
    {

        Vector3 nuevaPosicion = (mainCamera.transform.forward * distance) + mainCamera.transform.position + new Vector3(-x, -y, -z);
        o.transform.position = nuevaPosicion;

    }

    public void pickup()
    {

        //robot.DarPalabraActual("NeumannLevantarPrimeraParte");
        //robot.Speak();


        Pickupable p = selectedObject.gameObject.GetComponent<Pickupable>();
        if (p != null)
        {
            p.gameObject.GetComponent<ObjetoSeleccionado>().Seleccion();
            carrying = true;
            if (p.gameObject.GetComponent<Animator>() != null)
            {
                p.gameObject.GetComponent<Animator>().enabled = false;
            }
            carriedObject = p.gameObject;
            if (p.gameObject.GetComponent<Rigidbody>() != null)
            {
                p.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            }
            p.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }

    public void SoltarEnPortales()
    {
        if (carrying)
        {
            carriedObject.gameObject.GetComponent<BoxCollider>().enabled = true;
            carrying = false;
            if (carriedObject.gameObject.GetComponent<Rigidbody>() != null)
            {
                carriedObject.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            }
            if (carriedObject.gameObject.GetComponent<Animator>() != null)
            {
                carriedObject.gameObject.GetComponent<Animator>().enabled = true;
            }
            carriedObject.GetComponent<Pickupable>().Posicionarse();

            carriedObject = null;
        }
    }
    void checkDrop()
    {
        if (Input.GetMouseButtonDown(1))
        {
            dropObject();
        }
    }

    public void Seleccionarlo()
    {
        selectedObject.gameObject.GetComponent<Collider>().GetComponent<ObjetoSeleccionado>().Seleccion();
    }
    public void dropObject()
    {
        carriedObject.gameObject.GetComponent<BoxCollider>().enabled = true;
        carrying = false;
        if (carriedObject.gameObject.GetComponent<Rigidbody>() != null)
        {
            carriedObject.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }
        if (carriedObject.gameObject.GetComponent<Animator>() != null)
        {
            carriedObject.gameObject.GetComponent<Animator>().enabled = true;
        }

        carriedObject = null;
    }

    public string ReturnTag()
    {
        if (carrying)
        {
            return carriedObject.gameObject.tag;
        }
        else
        {
            return "";
        }
    }

    public void AnimarRobot()
    {
        //robot.Animar(objetoObservado.FraseActual());
    }

}
