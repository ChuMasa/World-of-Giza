using UnityEngine;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.Playables; // PlayableDirectorを使うために必要

public class FadeOutDecal : MonoBehaviour
{
    // Decal Projector component
    private DecalProjector decal;

   // Opacity value
// Opacity value
private float opacity;

// Speed of opacity change
public float speed = 0.001f;

// PlayableDirector component
public PlayableDirector director; // インスペクターでオブジェクトを指定できるようにpublicにする

// Flag to indicate if the timeline is stopped
private bool flag = false; // 初期値はfalseにする

// Start is called before the first frame update
void Start()
{
    // Get the Decal Projector component
    decal = GetComponent<DecalProjector>();
    // Set the initial opacity to zero
    opacity = 1f;
    // Update the material property
    decal.material.SetColor("_BaseColor", new Color(1f, 1f, 1f, opacity));
    // Add a listener to the stopped event of the PlayableDirector
    director.stopped += OnTimelineStopped;
}

// Update is called once per frame
void Update()
{
    if(flag){
    // Increase the opacity by speed
        opacity -= speed;
        // Clamp the opacity between 0 and 1
        opacity = Mathf.Clamp(opacity, 0f, 1f);
        // Update the material property
        decal.material.SetColor("_BaseColor", new Color(1f, 1f, 1f, opacity));
}
}

// This method is called when the timeline is stopped
void OnTimelineStopped(PlayableDirector pd)
{
    // Check if the stopped timeline is the same as the director
    if (pd == director)
    {
        // Set the flag to true
        flag = true; // Timelineが停止されたらflagをtrueにする
    }
}


}
