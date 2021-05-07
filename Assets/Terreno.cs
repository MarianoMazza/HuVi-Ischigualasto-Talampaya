using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terreno : MonoBehaviour
{
    // Start is called before the first frame update

    public Material referencedMaterial;
    public Terrain referencedTerrain;
    public Material cielo;

    void Start()
    {
        referencedTerrain.materialTemplate = referencedMaterial;
        RenderSettings.skybox = cielo;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
