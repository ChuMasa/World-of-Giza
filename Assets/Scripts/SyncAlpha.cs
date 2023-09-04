using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyncAlpha : MonoBehaviour
{
    // 親のCanvas Groupコンポーネントの参照
    private CanvasGroup canvasGroup;

    // 子のSpriteRendererコンポーネントの参照
    private SpriteRenderer spriteRenderer;

    // 色の変数
    private Color color;

    void Start()
    {
        // 親のCanvas Groupコンポーネントを取得
        canvasGroup = GetComponentInParent<CanvasGroup>();

        // 子のSpriteRendererコンポーネントを取得
        spriteRenderer = GetComponent<SpriteRenderer>();

        // 初期色を取得
        color = spriteRenderer.color;
    }

    void Update()
    {
        // 親のAlpha値を子の色のA値に反映させる
        color.a = canvasGroup.alpha;

        // 色を更新
        spriteRenderer.color = color;
    }
}
