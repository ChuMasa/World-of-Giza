using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deactivate : MonoBehaviour
{
    void Update()
    {
        // １キーが押されたら
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            // オブジェクトを非アクティブにする
            gameObject.SetActive(false);
        }
    }
}

