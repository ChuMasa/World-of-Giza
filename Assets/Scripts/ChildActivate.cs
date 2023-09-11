using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildActivate : MonoBehaviour
{
    // 子オブジェクトの参照を保持する変数
    private GameObject child;

    // 親オブジェクトが生成されたときに呼ばれるメソッド
    private void Awake()
    {
        // 子オブジェクトを取得する
        child = transform.GetChild(0).gameObject;
    }

    // 毎フレーム呼ばれるメソッド
    private void Update()
    {
        // ２キーが押されたら
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            // 子オブジェクトをアクティブにする
            child.SetActive(true);
        }
    }
}
