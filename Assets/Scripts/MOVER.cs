using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOVER : MonoBehaviour
{
    public float speed = 3.5f;
    private float gravity = 10f;
    private CharacterController controller;
    Vector3 pos;
    public GameObject Player;
    public GameObject inicio;
    public GameObject camera;
    public Camera mainCamera;
    public float minimumRotationX;
    int cont = 0;
    public KeyCode noController;
    float velocidad = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        //inicio.SetActive(true);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadPlus))
        {
            velocidad += 0.05f;
        }
        if (Input.GetKeyDown(KeyCode.KeypadMinus))
        {
            velocidad -= 0.05f;
        }
        if (Input.GetKeyDown(noController))
        {
            GetComponent<CharacterController>().enabled = !GetComponent<CharacterController>().enabled;
        }
        if (Player.transform.position.y < -20)
        {
            GetComponent<DemoPlayerController>().enabled = false;
            Player.transform.position = new Vector3(0, 2.20f, 0);
            //GetComponent<DemoPlayerController>().enabled = true;
        }
        else {
            MoverJugador();
        }

    }

    void MoverJugador(){


        //float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = 1;
        float altura = 0;
        //Debug.Log(vertical);
        if (Input.GetKey(KeyCode.Z))
        {
            transform.position += transform.up * velocidad;
        }
        if (Input.GetKey(KeyCode.X))
        {
            transform.position -= transform.up * velocidad;
        }
        if (Input.GetKey(KeyCode.V))
        {
            transform.position += transform.forward * velocidad;
        }
        if (Input.GetKey(KeyCode.B))
        {
            transform.position -= transform.forward * velocidad;
        }
        Vector3 direccion = new Vector3( horizontal, altura, vertical);
        Vector3 vel = direccion * speed;
        vel = Camera.main.transform.TransformDirection(vel);
        
        Vector3 rotation = new Vector3();
        rotation = mainCamera.transform.localRotation.eulerAngles;
        float rotationX = rotation.x;
        float rotationY = rotation.y;
        //Debug.Log(camera.transform.rotation.x);
        //Debug.Log(rotationX);
        if (rotationX >= minimumRotationX && rotationX < 200)
        {
            vel.y -= gravity;
            controller.Move(vel * Time.deltaTime);
            pos = new Vector3(0.0f, 2.0f, 0.0f);
        }//else if (Input.GetKeyDown(KeyCode.Z))
        //{
        //    vel.y = 8;
         //   controller.Move(vel * Time.deltaTime);
        //}

            //pos = Player.transform.position;
    }
}
