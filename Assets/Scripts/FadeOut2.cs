using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Canvas Groupコンポーネントの参照
    private CanvasGroup canvasGroup;

    // フェードアウトの速度
    public float fadeSpeed = 0.01f;

    void Start()
    {
        // Canvas Groupコンポーネントを取得
        canvasGroup = GetComponent<CanvasGroup>();
    }

    void Update()
    {
        // １キーが押されたら
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            // フェードアウト開始
            StartCoroutine("Fade");
        }
    }

    // フェードアウトするコルーチン
    IEnumerator Fade()
    {
        // Alpha値が0になるまで繰り返す
        while (canvasGroup.alpha > 0)
        {
            // Alpha値を減らす
            canvasGroup.alpha -= fadeSpeed;

            // 1フレーム待つ
            yield return null;
        }
    }
}
