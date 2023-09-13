using UnityEngine;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.Playables; // Timeline APIを使うために必要

public class FadeInDecal : MonoBehaviour
{
    // Decal Projector component
    private DecalProjector decal;

    // Opacity value
    private float opacity;

    // Speed of opacity change
    public float speed = 0.001f;

    private bool flag = false;

    // Timeline2のインスタンス
    public GameObject timeline1;


    // Start is called before the first frame update
    void Start()
    {
        // Get the Decal Projector component
        decal = GetComponent<DecalProjector>();
        // Set the initial opacity to zero
        opacity = 0f;
        // Update the material property
        decal.material.SetColor("_BaseColor", new Color(1f, 1f, 1f, opacity));

        // Timeline2のPlayableDirectorコンポーネントを取得
        PlayableDirector director1 = timeline1.GetComponent<PlayableDirector>();
        // playedイベントにリスナーを登録
        director1.played += OnTimeline1Played;

    }

    // Update is called once per frame
    void Update()
    {
        // Check if the 1 key is pressed
        if(flag){
            // Increase the opacity by speed
            opacity += speed;
            // Clamp the opacity between 0 and 1
            opacity = Mathf.Clamp(opacity, 0f, 1f);
            // Update the material property
            decal.material.SetColor("_BaseColor", new Color(1f, 1f, 1f, opacity));
        }
    }

    // Timeline2が再生開始したときに呼び出されるメソッド
    void OnTimeline1Played(PlayableDirector obj)
    {
        flag = true;
    }
}