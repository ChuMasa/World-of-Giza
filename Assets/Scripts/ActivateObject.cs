using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class ActivateObject : MonoBehaviour
{
    // オブジェクトを参照する変数
    public GameObject targetObject1;
    public GameObject targetObject2;
    public GameObject targetObject3;

   // Playable Director コンポーネントを参照する変数
private PlayableDirector director1;
private PlayableDirector director2;
private PlayableDirector director3;

// Start is called before the first frame update
void Start()
{
    // Playable Director コンポーネントを取得
    director1 = targetObject1.GetComponent<PlayableDirector>();
    director2 = targetObject2.GetComponent<PlayableDirector>();
    director3 = targetObject3.GetComponent<PlayableDirector>();
    // Update Method を Game Time に設定
    director1.timeUpdateMode = DirectorUpdateMode.GameTime;
    director2.timeUpdateMode = DirectorUpdateMode.GameTime;
    director3.timeUpdateMode = DirectorUpdateMode.GameTime;
    // タイムラインの再生を停止する
    director1.Stop();
    director2.Stop();
    director3.Stop();
}

// Update is called once per frame
void Update()
{
    // ０キーが押されたら
    if (Input.GetKeyDown(KeyCode.Alpha1))
    {
        // タイムラインを再生する
        director1.Play();
        // 他のタイムラインの再生を停止する
        director2.Stop();
        director3.Stop();
    }
    if (Input.GetKeyDown(KeyCode.Alpha2))
    {
        // タイムラインを再生する
        director2.Play();
        // 他のタイムラインの再生を停止する
        director1.Stop();
        director3.Stop();
    }
    if (Input.GetKeyDown(KeyCode.Alpha3))
    {
        // タイムラインを再生する
        director3.Play();
        // 他のタイムラインの再生を停止する
        director1.Stop();
        director2.Stop();
    }
    
}

}