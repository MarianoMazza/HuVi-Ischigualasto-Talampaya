    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeteccionPortales : MonoBehaviour
{
    private float nextActionTime = 0.0f;
    public float period = 2f;
    public GameObject sorpresa;
    public GameObject robotRoot;
    public GameObject camara;
    public Robot robot;
    bool activar = false;
    bool comienzo = false; bool terminoComienzo = false;
    //Collider objetoChocado;
    bool salaDerecha, salaIzquierda, salaCentral = false;
    public GameObject puertaInicial;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("DoCheck");
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time > nextActionTime && terminoComienzo)
        {

            nextActionTime += period;
            if (!this.gameObject.GetComponent<MOVER>().enabled) { 
            this.gameObject.GetComponent<DemoPlayerController>().enabled = true;
            this.gameObject.GetComponent<MOVER>().enabled = true;
            }
            //if(objetoChocado != null) { 
            //camara.transform.rotation = objetoChocado.gameObject.GetComponent<Portal>().RotacionCamara();
            //     objetoChocado = null;
            // }
        }
        //StartCoroutine("DoCheck");
        /*if (activar) {
            activar = false;
            this.gameObject.GetComponent<MOVER>().enabled = true;
        }*/
    }


    private void OnCollisionEnter(Collision collision)
    {
       /* Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == "Portal")
        {
            this.gameObject.transform.position = new Vector3(-1.490006f, 135, -37.74989f);
        }
        else if (collision.gameObject.name == "Portal2")
        {
            this.gameObject.transform.position = new Vector3(-38, 1.6f, 0);
        }*/
    }

    void OnTriggerEnter(Collider collision)
    {
   
       /* if (collision.gameObject.name == "Portal")
        {

            this.gameObject.GetComponent<DemoPlayerController>().enabled= false;
            this.gameObject.GetComponent<MOVER>().enabled = false;
            this.gameObject.GetComponent<Descendify>().resetCounter();
            this.gameObject.GetComponent<Descendify>().enabled = false;
            collision.gameObject.GetComponent<Portal>().ActivarSala();
            transform.position = collision.gameObject.GetComponent<Portal>().PosicionTeletransportacion();
            camara.transform.rotation = collision.gameObject.GetComponent<Portal>().RotacionCamara();
            objetoChocado = collision;

            //ESTO ES PARA EL ROBOT
            Vector3 playerPos = collision.gameObject.GetComponent<Portal>().siguientePortal.transform.position;
Vector3 playerDirection = collision.gameObject.GetComponent<Portal>().siguientePortal.transform.forward;
            Quaternion playerRotation = collision.gameObject.GetComponent<Portal>().siguientePortal.transform.rotation;
            float spawnDistance = 0.1f;
Vector3 spawnPos = playerPos + playerDirection * spawnDistance;



            //robot.GetComponent<Robot>().rotacionPrueba = collision.gameObject;
            robotRoot.transform.position = spawnPos;
            robotRoot.transform.rotation = collision.gameObject.GetComponent<Portal>().siguientePortal.transform.rotation;
            //robotRoot.transform.position = new Vector3(transform.position.x + 2, transform.position.y + 0.85f, transform.position.z);
            //robotRoot.transform.rotation = collision.gameObject.GetComponent<Portal>().RotacionRobot();
            //robotRoot.transform.rotation = camara.transform.rotation;

            /*Vector3 playerPos = transform.position;
   Vector3 playerDirection = transform.forward;
   Quaternion playerRotation = transform.rotation;
   float spawnDistance = 10;
   Vector3 spawnPos = playerPos + playerDirection * spawnDistance;*/

           //robot.Animar(collision.gameObject.GetComponent<Portal>().FraseActual());
           // StartCoroutine("DoCheck");
        //}
        if (collision.gameObject.name == "ColliderComienzo" && !comienzo)
        {
            robot.Animar("Introduccion1");
            comienzo = false;
            this.gameObject.GetComponent<MOVER>().enabled = false;
            comienzo = true;
        }
            if (collision.gameObject.name == "SalaDerecha")
        {
            if (!salaDerecha)
            {
                robot.Animar("SalaDerecha");
                salaDerecha = true;
            }
            else {
                robot.Animar("SalirSalaDerecha");
                salaDerecha = false;
            }
        }
        if (collision.gameObject.name == "SalaIzquierda")
        {
            if (!salaIzquierda)
            {
                robot.Animar("EntrarSalaIzquierda");
                salaIzquierda = true;
            }
            else {
                robot.Animar("SalirSalaIzquierda");
                salaIzquierda = false;
            }
        }
        if (collision.gameObject.name == "SalaCentral")
        {
            if (!salaCentral)
            {
                robot.Animar("EntrarSalaCentral");
                salaCentral = true;
            }
            else {
                robot.Animar("SalirSalaCentral");
                salaCentral = false;
            }
        }

    }

    public void TerminoComienzo() {
        terminoComienzo = true;
        puertaInicial.SetActive(true);
    }
    IEnumerator DoCheck()
    {
        while (true) { 
            // execute block of code here
            activar = true;
            yield return new WaitForSeconds(5f);
            //StartCoroutine("DoCheck");
        }
    }
}
