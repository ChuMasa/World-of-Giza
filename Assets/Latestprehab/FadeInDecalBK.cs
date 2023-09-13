using UnityEngine;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.Playables; // PlayableDirectorを使うために必要

public class FadeInDecalBK : MonoBehaviour
{
    // Decal Projector component
    private DecalProjector decal;

    // Opacity value
    private float opacity;

    // Speed of opacity change
    public float speed = 0.1f;

    // PlayableDirector component
    private PlayableDirector director;

    // Scene names
    public string[] sceneNames; // インスペクターからシーンの名前を入力する

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

        // Get the PlayableDirector component
        director = GetComponent<PlayableDirector>();
        // Add a listener to the played event of the director
        director.played += OnTimelinePlayed;
        // Add a listener to the stopped event of the director
        director.stopped += OnTimelineStopped;
    }

    // Update is called once per frame
    void Update()
    {
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

    // This method is called when a timeline starts playing
    void OnTimelinePlayed(PlayableDirector dir)
    {
        // Check which scene name is playing
        if (dir.playableAsset.name == sceneNames[0])
        {
            // Set the flag1 to true and flag2 to false
            flag1 = true;
            flag2 = false;
        }
        else if (dir.playableAsset.name == sceneNames[1])
        {
            // Set the flag2 to true and flag1 to false
            flag2 = true;
            flag1 = false;
        }
    }

    // This method is called when a timeline stops playing
    void OnTimelineStopped(PlayableDirector dir)
    {
        // Reset both flags to false
        flag1 = false;
        flag2 = false;
    }
}
