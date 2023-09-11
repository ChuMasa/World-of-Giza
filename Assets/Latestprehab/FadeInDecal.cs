using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

public class FadeInDecal : MonoBehaviour
{
    // Decal Projector component
    private DecalProjector decal;

    // Opacity value
    private float opacity;

    // Speed of opacity change
    public float speed = 0.1f;

 private bool flag1 = false;
 private bool flag2 = false;

// Start is called before the first frame update
void Start()
{
    // Get the Decal Projector component
    decal = GetComponent<DecalProjector>();
    // Set the initial opacity to zero
    opacity = 0f;
    // Update the material property
    decal.material.SetColor("_BaseColor", new Color(1f, 1f, 1f, opacity));
}

// Update is called once per frame
void Update()
{
    // Check if the 1 key is pressed
    if (Input.GetKeyDown(KeyCode.Alpha1))
    {
        // Set the flag1 to true and flag2 to false
        flag1 = true;
        flag2 = false;
    }
    if(flag1){
    // Increase the opacity by speed
        opacity += speed;
        // Clamp the opacity between 0 and 1
        opacity = Mathf.Clamp(opacity, 0f, 1f);
        // Update the material property
        decal.material.SetColor("_BaseColor", new Color(1f, 1f, 1f, opacity));
        // Check if the opacity reaches 1
        if (opacity == 1f)
        {
            // Reset the flag1 to false
            flag1 = false;
        }
}

    // Check if the 2 key is pressed
    if (Input.GetKeyDown(KeyCode.Alpha2))
    {
        // Set the flag2 to true and flag1 to false
        flag2 = true;
        flag1 = false;
    }
    if(flag2){
    // Decrease the opacity by speed
        opacity -= speed;
        // Clamp the opacity between 0 and 1
        opacity = Mathf.Clamp(opacity, 0f, 1f);
        // Update the material property
        decal.material.SetColor("_BaseColor", new Color(1f, 1f, 1f, opacity));
        // Check if the opacity reaches 0
        if (opacity == 0f)
        {
            // Reset the flag2 to false
            flag2 = false;
        }
	}
}

}
