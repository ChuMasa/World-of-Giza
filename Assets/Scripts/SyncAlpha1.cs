using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyncAlpha1 : MonoBehaviour
{
    // 親のCanvas Groupコンポーネントの参照
    private CanvasGroup canvasGroup;

    // 子のSpriteRendererコンポーネントの参照
    private Material material;

    // 色の変数
    private Color color;

    void Start()
    {
        // 親のCanvas Groupコンポーネントを取得
        canvasGroup = GetComponentInParent<CanvasGroup>();

        // 子のSpriteRendererコンポーネントを取得
        material= GetComponent<Material>();

        // 初期色を取得
        color = material.color;
    }

    void Update()
    {
        // 親のAlpha値を子の色のA値に反映させる
        color.a = canvasGroup.alpha;

        // 色を更新
        material.color = color;
    }
}
