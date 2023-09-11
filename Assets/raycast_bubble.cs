using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycast_bubble : MonoBehaviour
{
    public GameObject calibrationCenter;
    public GameObject trackerOffset;

    void Start()
    {
        calibrationCenter = GameObject.Find("TrackerCalibration");
        trackerOffset = GameObject.Find("TrackerOffset");
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Raycast();
        }

        // Calibration
        if(Input.GetKeyDown(KeyCode.F1))
        {
            trackerOffset.transform.position = calibrationCenter.transform.position - transform.position;
        }

        
    }

    void Raycast()
    {

        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, 20f))
        {

            if (hit.collider.gameObject.tag == "bubble")
            {
                Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.yellow);
                hit.collider.GetComponent<point_of_interest>().NextMaterial();
            } else if (hit.collider.gameObject.tag == "timeline") {
                if(hit.collider.gameObject.name == "Collider1") {
                    // change timeline to 1
                } else if(hit.collider.gameObject.name == "Collider2") {
                    // change timeline to 2
                } else if (hit.collider.gameObject.name == "Collider3") {
                    // change timeline to 3
                }
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
