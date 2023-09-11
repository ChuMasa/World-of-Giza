using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUmanObjectRotation : MonoBehaviour
{
// 回転速度
public float speed = 0.1f;
// 回転角度
public float angle = 90f;
private float def_angle = 0f;
// 回転開始位置
private Quaternion startRot;
// 回転中かどうか
private bool rotating = true;
//private bool flag = false;
//private float timeValue3 = 0f; // 1キーが押されたときの値

// 値のMax
//private float maxValue = 10f;

// 回転方向
public Vector3 axis = Vector3.up; // インスペクターから変更可能


// Start is called before the first frame update
void Start()
{
    // 回転開始位置を保存する
    startRot = transform.rotation;
	def_angle = angle;
}

// Update is called once per frame
void Update()
{
    // 回転中なら
    if (rotating) //&& timeValue3 >= maxValue
    {
        // axis方向にspeed分だけ回転する
        transform.Rotate(axis * speed * Time.deltaTime);
        // 回転角度を減らす
        angle -= speed * Time.deltaTime;
        // 回転角度がゼロ以下になったら
        if (angle <= 0)
        {
            // 回転中フラグをオフにする
            rotating = false;
            // 回転角度をリセットする
            angle = def_angle;
            // 角度を回転開始位置に戻す
            transform.rotation = startRot;
	rotating = true;

        }
    }
}

}
