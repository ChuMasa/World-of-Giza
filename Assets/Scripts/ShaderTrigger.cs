using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; using 
UnityEngine.Playables; // PlayableDirectorを使うために必要

public class ShaderTrigger : MonoBehaviour { // シェーダーグラフで作成したマテリアルへの参照 
public Material shaderGraphMaterial;
// Time ノードの値
private float timeValue1 = 0f; // Timeline1が再生されたときの値
private float timeValue2 = 0f; // Timeline2が再生されたときの値

// 値のMax
private float maxValue = 10f;

// Timeline1,2,3が再生されたかどうか
private bool timeline1Played = false;
private bool timeline2Played = false;
private bool timeline3Played = false;

// Timeline1,2,3のPlayableDirectorへの参照
private PlayableDirector timeline1;
private PlayableDirector timeline2;
private PlayableDirector timeline3;

void Start()
{
    // シェーダーグラフで作成したマテリアルの _RemapValue1 と _RemapValue2 を 0 に初期化する
    shaderGraphMaterial.SetFloat("_RemapValue1", 0f);
    shaderGraphMaterial.SetFloat("_RemapValue2", 0f);

    // Timeline1,2,3のPlayableDirectorを取得する
    timeline1 = GameObject.Find("Timeline1").GetComponent<PlayableDirector>();
    timeline2 = GameObject.Find("Timeline2").GetComponent<PlayableDirector>();
    timeline3 = GameObject.Find("Timeline3").GetComponent<PlayableDirector>();
}

void Update()
{
    // Timeline1が再生されたら
    if (timeline1.state == PlayState.Playing && !timeline1Played)
    {
        // timeline1Played を true にする
        timeline1Played = true;

        // timeValue1,2 を0fにリセットする
        timeValue1 = 0f;
        timeValue2 = 0f;

        // マテリアルの _RemapValue1,2 プロパティーに値を設定する
        GetComponent<Renderer>().sharedMaterial.SetFloat("_RemapValue1", timeValue1);
        GetComponent<Renderer>().sharedMaterial.SetFloat("_RemapValue2", timeValue2);

    }

    // Timeline2が再生されたら
    if (timeline2.state == PlayState.Playing && !timeline2Played)
    {
        // timeline2Played を true にする
        timeline2Played = true;
        timeline1Played = false;
        timeline3Played = false;

        // timeValue2 をリセットする
        timeValue1 = 0f;

        // オブジェクトに割り当てられた共有マテリアルにシェーダーグラフで作成したマテリアルを代入する
        GetComponent<Renderer>().sharedMaterial = shaderGraphMaterial;
    }

    // Timeline3が再生されたら
    if (timeline3.state == PlayState.Playing && !timeline3Played)
    {
        // timeline3Played を true にする
        timeline1Played = false;
        timeline2Played = false;
        timeline3Played = true;

        // timeValue2 を0fにリセットする
        timeValue2 = 0f;
        // オブジェクトに割り当てられた共有マテリアルにシェーダーグラフで作成したマテリアルを代入する
        GetComponent<Renderer>().sharedMaterial = shaderGraphMaterial;


    }

    // timeline2Played が true なら
    if (timeline2Played)
    {
        // timeValue1 を Delta Time で増やす
        timeValue1 += Time.deltaTime;

        // timeValue1 が maxValue を超えないようにする
        timeValue1 = Mathf.Min(timeValue1, maxValue);

        // マテリアルの _RemapValue1 プロパティーに値を設定する
        GetComponent<Renderer>().sharedMaterial.SetFloat("_RemapValue1", timeValue1);

        /*if (timeValue2 >=0)
        {
        // timeValue2 を Delta Time で減らす
        timeValue2 -= Time.deltaTime;

        // timeValue2 が 0 を下回らないようにする
        timeValue2 = Mathf.Max(timeValue2, 0f);

        // マテリアルの _RemapValue2 プロパティーに値を設定する
        GetComponent<Renderer>().sharedMaterial.SetFloat("_RemapValue2", timeValue2);
        }
            // デバッグログを追加する
            // timeValue1 の値をコンソールウィンドウに出力する
            Debug.Log("timeValue1: " + timeValue1);

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

    // timeline3Played が true なら
    if (timeline3Played)
    {
        // timeValue2 を Delta Time で増やす
        timeValue2 += Time.deltaTime;

        // timeValue2 が maxValue を超えないようにする
        timeValue2 = Mathf.Min(timeValue2, maxValue);

        // マテリアルの _RemapValue2 プロパティーに値を設定する
        GetComponent<Renderer>().sharedMaterial.SetFloat("_RemapValue2", timeValue2);
        
    }

    // timeline3Played が true なら
    if (timeline1Played)
    {
        // timeline3Played を false に戻す（一度だけ実行させるため）
        timeline3Played = false;
        timeline2Played = false;
        timeline1Played = false;
    }

    // timeline3Played の後に timeline2Played になったら

}
}
