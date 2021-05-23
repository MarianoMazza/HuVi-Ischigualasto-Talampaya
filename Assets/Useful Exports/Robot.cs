using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    public GameManagerScript manager;
    public AudioClip[] speech;
    public AudioSource auSource;
    string palabraActual;
    string palabraAnterior = "a";
    public GameObject robotRoot;
    Quaternion inicial;
    int primerPalabra = 0;
    bool onlyOnce = false;
    public Gaze jugador;
    public bool terminoComienzo;

    void Start()
    {
        inicial = transform.parent.rotation;
    }

    public void RobotHabla()
    {
        //jugador.RobotHabla();
    }
    public void AnularPalabra()
    {
        palabraActual = null;
    }

    public void Animar(string nombreAnimacion)
    {
        //Debug.Log(nombreAnimacion);
        if (nombreAnimacion.Contains("Recompensa") && onlyOnce == false)
        {
            primerPalabra++;
        }
        if (primerPalabra != 1)
        {
            if (nombreAnimacion != "")
            {
                palabraAnterior = palabraActual;
                palabraActual = nombreAnimacion;
            }
            this.gameObject.GetComponent<Animator>().SetTrigger(nombreAnimacion);
        }
        else { onlyOnce = true; primerPalabra = 0; }
    }

    public void DarPalabraActual(string palabra)
    {
        palabraAnterior = palabraActual;
        palabraActual = palabra;
    }
    public int FindAudio(string audioName)
    {
        for (int i = 0; i < speech.Length; i++)
        {
            if (speech[i].name == audioName)
            {
                return i;
            }
        }
        return -1;
    }

    public void Speak()
    {
        //Convert the string to the audioClip index

        int audioIndex = FindAudio(palabraActual);

        if (audioIndex != -1)
        {

            //Assign the clip to play
            auSource.clip = speech[audioIndex];

            //Play
            auSource.Play();

        }

    }

    public void Root()
    {

        // update the parent position
        transform.parent.position = transform.position;
        transform.parent.rotation = transform.rotation;
        // update the box position to zero inside the parent
        transform.localPosition = Vector3.zero;
    }
    public void RootCentral()
    {
        // update the parent position
        transform.parent.position = new Vector3(-0.07123973f, 0.4811721f, 9.51298f);
        transform.parent.rotation = inicial;
    }


}
