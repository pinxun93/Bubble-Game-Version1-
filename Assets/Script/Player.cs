using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D m_rigidbody2D; // 建立一個2D剛體變數

    public float moveSpeed = 1.0f;     // 建立一個公開(public)浮點數moveSpeed

    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody2D = GetComponent<Rigidbody2D>(); // 遊戲一執行，取得外星人的剛體
    }

    // Update is called once per frame
    void Update()
    {
        // 如果按下鍵盤右方向鍵，讓外星人往X軸移動1
        if (Input.GetKey(KeyCode.RightArrow))
        {
            m_rigidbody2D.velocity = new Vector3(moveSpeed, 0, 0);
        }
        // 如果按下鍵盤左方向鍵，讓外星人往X軸移動-1，也就是往左移動1
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            m_rigidbody2D.velocity = new Vector3(-moveSpeed, 0, 0);
        }
        // 如果右方向鍵「或」左方向鍵，被「放開」的時候，就讓所有速度都歸0
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            m_rigidbody2D.velocity = new Vector3(0, 0, 0);
        }
        // 如果按下鍵盤空白鍵，讓外星人往Y軸移動1，也就是往上移動1
        if (Input.GetKey(KeyCode.Space))
        {
            m_rigidbody2D.velocity = new Vector3(0, moveSpeed, 0);
        }
    }
}