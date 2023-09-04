using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walkermove : MonoBehaviour
{
	// 移動スピード
    public float speed;
    // Start is called before the first frame update
    // 開始位置を保持する変数
    private Vector3 startPosition;

    // アニメーターを保持する変数
    private Animator animator;

    void Start()
    {
        // 開始位置を現在位置として記録
        startPosition = transform.position;

        // アニメーターを取得
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
// 前に移動する
        transform.position += transform.forward * speed * Time.deltaTime;
        
    }
// トリガーと衝突した時に呼ばれるメソッド
    private void OnTriggerEnter(Collider other)
    {
        // トリガーのタグが"Respawn"なら
        if (other.CompareTag("Respawn"))
        {
            // 位置を開始位置に戻す
            transform.position = startPosition;

            // アニメーションを再生する
            animator.Play("YourAnimationName");
        }
    }
}
