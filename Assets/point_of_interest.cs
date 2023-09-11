using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class point_of_interest : MonoBehaviour
{
    public int index = 0;
    public GameObject anubis;


    public void NextMaterial()
    {
        anubis.GetComponent<Anubis>().SelectPointOfInterest(index);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
