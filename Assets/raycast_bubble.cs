using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycast_bubble : MonoBehaviour
{
    public GameObject[] bubbles;

    void Start()
    {
        bubbles = GameObject.FindGameObjectsWithTag("bubble");
    }

    // Update is called once per frame
    void Update()
    {

        foreach (GameObject bubble in bubbles)
        {
            bubble.GetComponent<UnityEngine.Rendering.HighDefinition.DecalProjector>().enabled = false;
        }

        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, 20f))
        {

            if (hit.collider.gameObject.tag == "bubble")
            {
                Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.yellow);
                hit.collider.gameObject.GetComponent<UnityEngine.Rendering.HighDefinition.DecalProjector>().enabled = true;
            }
            else
            {
                Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.red);
            }
        }
        else
        {
            Debug.DrawRay(transform.position, transform.forward * 20f, Color.white);
        }
    }
}
