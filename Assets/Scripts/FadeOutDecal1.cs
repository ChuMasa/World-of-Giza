using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

public class FadeOutDecal1 : MonoBehaviour
{
    // Decal Projector component
    private DecalProjector decal;

    // Opacity value
    private float opacity;

    // Speed of opacity change
    public float speed = 0.1f;

 private bool flag = false;

    // Start is called before the first frame update
    void Start()
    {
        // Get the Decal Projector component
        decal = GetComponent<DecalProjector>();
        // Set the initial opacity to zero
        opacity = 1f;
        // Update the material property
        decal.material.SetColor("_BaseColor", new Color(1f, 1f, 1f, opacity));
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the 1 key is pressed
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {

		flag = true;
        }
        if(flag){
	    // Increase the opacity by speed
            opacity -= speed;
            // Clamp the opacity between 0 and 1
            opacity = Mathf.Clamp(opacity, 0f, 1f);
            // Update the material property
            decal.material.SetColor("_BaseColor", new Color(1f, 1f, 1f, opacity));
	}
    }
}
