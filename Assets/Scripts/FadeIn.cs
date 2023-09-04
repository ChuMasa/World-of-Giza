using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn : MonoBehaviour
{
    // フェードインにかかる時間（秒）
    public float fadeTime = 0.01f;

    // マテリアルの参照
    private Material material;

    // アルファ値
    private float alpha = 0f;

    // フェードインが完了したかどうか
    private bool isFadedIn = false;

    void Start()
    {
        // マテリアルを取得
        material = GetComponent<Renderer>().material;
        // アルファ値を初期化
        SetAlpha(0f);
    }

    void Update()
    {
        // フェードインが完了していない場合
        if (!isFadedIn)
        {
            // アルファ値を徐々に増やす
            alpha += fadeTime;
            // アルファ値を設定
            SetAlpha(alpha);
            // アルファ値が1になったらフェードイン完了
            if (alpha >= 1f)
            {
                isFadedIn = true;
            }
        }
    }

    // アルファ値を設定するメソッド
    void SetAlpha(float a)
    {
        // 色を取得
        Color color = material.color;
        // アルファ値を変更
        color.a = a;
        // 色を設定
        material.color = color;
    }
}

