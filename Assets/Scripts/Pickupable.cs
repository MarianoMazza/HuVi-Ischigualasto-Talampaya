using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickupable : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 posicion;
    void Start()
    {
        posicion = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Posicionarse()
    {
        transform.position = posicion;
    }
}
