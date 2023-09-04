using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class ActivateObject : MonoBehaviour
{
    // オブジェクトを参照する変数
    public GameObject targetObject;

    // Playable Director コンポーネントを参照する変数
    private PlayableDirector director;

    // Start is called before the first frame update
    void Start()
    {
        // Playable Director コンポーネントを取得
        director = GetComponent<PlayableDirector>();
        // Update Method を Game Time に設定
        director.timeUpdateMode = DirectorUpdateMode.GameTime;
        // オブジェクトのアクティブ状態を非アクティブに設定
        targetObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // ０キーが押されたら
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            // オブジェクトのアクティブ状態を反転する
            targetObject.SetActive(!targetObject.activeSelf);
            // オブジェクトがアクティブになったら
            if (targetObject.activeSelf)
            {
                // タイムラインを再生する
                director.Play();
            }
        }
    }
}
