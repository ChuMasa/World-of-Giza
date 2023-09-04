using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureSwitcher : MonoBehaviour 
{
public Texture[] textures; // テクスチャの配列をインスペクターで設定する
public float fadeTime = 1f; // フェードにかかる時間をインスペクターで設定する
private int index = 0; // 現在のテクスチャのインデックス
private bool fading = false; // フェード中かどうかのフラグ
private Material material; // オブジェクトのマテリアル
private Material oldmaterial; // 旧マテリアル

void Start () {
    material = GetComponent<Renderer>().material; // オブジェクトのマテリアルを取得する
    material.mainTexture = textures[index]; // 最初のテクスチャを適用する
    oldmaterial = new Material(material); // 旧マテリアルを作成する
    oldmaterial.mainTexture = textures[index]; // 旧マテリアルにも最初のテクスチャを適用する
}

void Update () {
    if (Input.GetKeyDown(KeyCode.Space) && !fading) { // スペースキーが押されたとき、かつフェード中でないとき
        StartCoroutine(FadeToNextTexture()); // フェードのコルーチンを開始する
    }
}

IEnumerator FadeToNextTexture () {
    fading = true; // フェード中にする
    float time = 0f; // 経過時間を初期化する
    Color color = material.color; // マテリアルの色を取得する
    Color oldcolor = oldmaterial.color; // 旧マテリアルの色も取得する
    index = (index + 1) % textures.Length; // 次のテクスチャのインデックスを計算する
    material.mainTexture = textures[index]; // 次のテクスチャを適用する
    while (time < fadeTime) { // フェード時間に達するまで繰り返す
        time += Time.deltaTime; // 経過時間を更新する
        color.a = FadeColorToLevel(0f, 1f, time / fadeTime); // 新マテリアルのアルファ値を増やす
        oldcolor.a = FadeColorToLevel(1f, 0f, time / fadeTime); // 旧マテリアルのアルファ値を減らす
        material.color = color; // 新マテリアルの色を変更する
        oldmaterial.color = oldcolor; // 旧マテリアルの色も変更する

        material.Lerp(oldmaterial, material, time / fadeTime); // 現在のマテリアルは旧マテリアルと新マテリアルの合成を表示する

        yield return null; // 次のフレームまで待つ
    }
    fading = false; // フェード終了にする
}

float FadeColorToLevel (float from, float to, float t) {
    return Mathf.Lerp(from, to, t); // fromからtoへtの割合で線形補間する関数
}

}
