using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn2 : MonoBehaviour
{
    public float fadeSpeed = 0.01f;
    private CanvasGroup canvasGroup;
    // Start is called before the first frame update
    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        
    }

    // Update is called once per frame
    void Update()
    {
            // １キーが押されたら
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            StartCoroutine("Fade");

        }
        
    }

            // フェードアウトするコルーチン
    IEnumerator Fade()
    {
        // Alpha値が0になるまで繰り返す
        while (canvasGroup.alpha < 1)
        {
            // Alpha値を減らす
            canvasGroup.alpha += fadeSpeed;

            // 1フレーム待つ
            yield return null;
        }
    }


}
