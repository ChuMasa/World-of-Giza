using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deacktivate2 : MonoBehaviour
{
    void Update()
    {
        // １キーが押されたら
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            // オブジェクトを非アクティブにする
            gameObject.SetActive(false);
        }
    }
}
