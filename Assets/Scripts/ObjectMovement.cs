using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{

    // 移動速度
    public float speed = 5f;
    // 移動距離
    public float distance = 10f;
    // 移動開始位置
    private Vector3 startPos;
    // 移動中かどうか
    private bool moving = false;
    //private bool flag = false;
    //private float timeValue3 = 0f; // 1キーが押されたときの値

    // 値のMax
    //private float maxValue = 10f;


    // Start is called before the first frame update
    void Start()
    {
        // 移動開始位置を保存する
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // １キーが押されたら
       // if (Input.GetKeyDown(KeyCode.Alpha1))
       // {
            // 移動中でなければ
            if (!moving)
            {
                // 移動中フラグをオンにする
                moving = true;
                //flag = true;
            }
       // }
/*      if(flag){
        timeValue3 += Time.deltaTime;
        }
*/
        // 移動中なら
        if (moving) //&& timeValue3 >= maxValue
        {
            // x軸方向にspeed分だけ移動する
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            transform.Translate(Vector3.down * 1/8 * speed * Time.deltaTime);
            // 移動距離を減らす
            distance -= speed * Time.deltaTime;
            // 移動距離がゼロ以下になったら
            if (distance <= 0)
            {
                // 移動中フラグをオフにする
                moving = false;
                // 移動距離をリセットする
                distance = 10f;
                // 位置を移動開始位置に戻す
                transform.position = startPos;
            }
        }
    }

}