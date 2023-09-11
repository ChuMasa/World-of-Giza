using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acruvate2 : MonoBehaviour
{
    void Update()
    {
        // 2キーが押されたら
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            // オブジェクトをアクティブにする
            gameObject.SetActive(true);
        }
    }
}

