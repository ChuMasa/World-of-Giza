using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanObjectMovement : MonoBehaviour
{
// 移動速度
public float speed = 0.003f;
// 移動距離
public float distance = 0.05f;
private float def_distance = 0f;
// 移動開始位置
private Vector3 startPos;
// 移動中かどうか
private bool moving = true;
//private bool flag = false;
//private float timeValue3 = 0f; // 1キーが押されたときの値

// 値のMax
//private float maxValue = 10f;

// 移動方向
public Vector3 direction = Vector3.left; // インスペクターから変更可能


// Start is called before the first frame update
void Start()
{
    // 移動開始位置を保存する
    startPos = transform.position;
    def_distance = distance;

}

// Update is called once per frame
void Update()
{
    // 移動中なら
    if (moving) //&& timeValue3 >= maxValue
    {
        // direction方向にspeed分だけ移動する
        transform.Translate(direction * speed * Time.deltaTime);
        // 移動距離を減らす
        distance -= speed * Time.deltaTime;
        // 移動距離がゼロ以下になったら
        if (distance <= 0)
        {
            // 移動中フラグをオフにする
            moving = false;
            // 移動距離をリセットする
            distance = def_distance;
            // 位置を移動開始位置に戻す
            transform.position = startPos;
	moving = true;

        }
    }
}
}
