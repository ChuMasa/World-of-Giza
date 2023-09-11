using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class point_of_interest : MonoBehaviour
{
    public Material[] materials;
    private int index = 0;


    public void NextMaterial()
    {
        index = (index + 1) % (materials.Length + 1);
        if (index == 0) {
            GetComponent<UnityEngine.Rendering.HighDefinition.DecalProjector>().enabled = false;
        } else {
            GetComponent<UnityEngine.Rendering.HighDefinition.DecalProjector>().enabled = true;
            GetComponent<UnityEngine.Rendering.HighDefinition.DecalProjector>().material = materials[index + 1];
        }
    }

    void Start()
    {
        if (index == 0) {
            GetComponent<UnityEngine.Rendering.HighDefinition.DecalProjector>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
