using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PointOfInterest
{
    public Material[] messages;
}

public class Anubis : MonoBehaviour
{
    

    // Start is called before the first frame update
    public PointOfInterest[] pointOfInterests;

    public int pointOfInterest = -1;
    private int message = 0;

    public void SelectPointOfInterest(int index)
    {
        if(pointOfInterest == index) {
            NextMessage();
            return;
        }

        pointOfInterest = index;
        message = 0;
        NextMessage();
    }

    public void NextMessage()
    {
        if (pointOfInterest == -1) {
            return;
        }

        message = (message + 1) % (pointOfInterests[pointOfInterest].messages.Length + 1);
        if (message == 0) {
            GetComponent<UnityEngine.Rendering.HighDefinition.DecalProjector>().material = null;
            pointOfInterest = -1;
        } else {
            GetComponent<UnityEngine.Rendering.HighDefinition.DecalProjector>().material = pointOfInterests[pointOfInterest].messages[message - 1];
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
