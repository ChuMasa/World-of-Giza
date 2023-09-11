using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderTrigger : MonoBehaviour
{
    // シェーダーグラフで作成したマテリアルへの参照
    public Material shaderGraphMaterial;
// Time ノードの値
private float timeValue1 = 0f; // 1キーが押されたときの値
private float timeValue2 = 0f; // 2キーが押されたときの値

// 値のMax
private float maxValue = 10f;

// 1キーと2キーと3キーが押されたかどうか
private bool key1Pressed = false;
private bool key2Pressed = false;
private bool key3Pressed = false;

void Start()
{
    // シェーダーグラフで作成したマテリアルの _RemapValue1 と _RemapValue2 を 0 に初期化する
    shaderGraphMaterial.SetFloat("_RemapValue1", 0f);
    shaderGraphMaterial.SetFloat("_RemapValue2", 0f);
}

void Update()
{
    // 1キーが押されたら
    if (Input.GetKeyDown(KeyCode.Alpha1))
    {
        // key1Pressed を true にする
        key1Pressed = true;

        // timeValue1 をリセットする
        timeValue1 = 0f;

        // オブジェクトに割り当てられた共有マテリアルにシェーダーグラフで作成したマテリアルを代入する
        GetComponent<Renderer>().sharedMaterial = shaderGraphMaterial;
    }

    // 2キーが押されたら
    if (Input.GetKeyDown(KeyCode.Alpha2))
    {
        // key2Pressed を true にする
        key2Pressed = true;

        // timeValue2 をリセットする
        timeValue2 = 0f;

        // オブジェクトに割り当てられた共有マテリアルにシェーダーグラフで作成したマテリアルを代入する
        GetComponent<Renderer>().sharedMaterial = shaderGraphMaterial;
    }

    // 3キーが押されたら
    if (Input.GetKeyDown(KeyCode.Alpha3))
    {
        // key3Pressed を true にする
        key3Pressed = true;

        // timeValue1,2 を0fにリセットする
        timeValue1 = 0f;
        timeValue2 = 0f;

        // マテリアルの _RemapValue1,2 プロパティーに値を設定する
        GetComponent<Renderer>().sharedMaterial.SetFloat("_RemapValue1", timeValue1);
        GetComponent<Renderer>().sharedMaterial.SetFloat("_RemapValue2", timeValue2);
    }

    // key1Pressed が true なら
    if (key1Pressed)
    {
        // timeValue1 を Delta Time で増やす
        timeValue1 += Time.deltaTime;

        // timeValue1 が maxValue を超えないようにする
        timeValue1 = Mathf.Min(timeValue1, maxValue);

        // マテリアルの _RemapValue1 プロパティーに値を設定する
        GetComponent<Renderer>().sharedMaterial.SetFloat("_RemapValue1", timeValue1);
    }

    // key2Pressed が true なら
    if (key2Pressed)
    {
        // timeValue2 を Delta Time で増やす
        timeValue2 += Time.deltaTime;

        // timeValue2 が maxValue を超えないようにする
        timeValue2 = Mathf.Min(timeValue2, maxValue);

        // マテリアルの _RemapValue2 プロパティーに値を設定する
        GetComponent<Renderer>().sharedMaterial.SetFloat("_RemapValue2", timeValue2);
    }

    // key3Pressed が true なら
    if (key3Pressed)
    {
        // key3Pressed を false に戻す（一度だけ実行させるため）
        key3Pressed = false;
        key2Pressed = false;
        key1Pressed = false;
    }

    /* timeValue1 の値をコンソールウィンドウに出力する
    //Debug.Log("timeValue1: " + timeValue1);

    // _RemapValue1 の値を取得する
    float remapValue1 = shaderGraphMaterial.GetFloat("_RemapValue1");

    // コンソールに出力する
    Debug.Log("RemapValue1: " + remapValue1);

    // timeValue2 の値をコンソールウィンドウに出力する
    Debug.Log("timeValue2: " + timeValue2);

    // _RemapValue2 の値を取得する
    float remapValue2 = shaderGraphMaterial.GetFloat("_RemapValue2");

    // コンソールに出力する
    Debug.Log("RemapValue2: " + remapValue2);*/
}


}

