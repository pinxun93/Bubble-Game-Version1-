using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D m_rigidbody2D;
    public float moveSpeed = 3f;
    public float jumpForce = 12f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;

    private float lastGroundedY; // 最後一次站在地面時的高度
    public float fallDeathThreshold = 6f; // 掉落多少距離就死亡

    public GameManager gameManager; // 拖 GameManager 進來

    private bool isGrounded = false;
    private Collider2D 碰撞器;
    void Start()
    {
        m_rigidbody2D = GetComponent<Rigidbody2D>();
        碰撞器 = this.GetComponent<Collider2D>();
        Invoke("InitialJump", 0.1f); // 避免初始重力干擾，延遲跳躍
    }

    void Update()
    {
        // 左右移動
        float moveX = 0f;
        if (Input.GetKey(KeyCode.RightArrow))
            moveX = moveSpeed;
        else if (Input.GetKey(KeyCode.LeftArrow))
            moveX = -moveSpeed;

        m_rigidbody2D.velocity = new Vector2(moveX, m_rigidbody2D.velocity.y);

        // 檢查是否著地
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (isGrounded && m_rigidbody2D.velocity.y <= 0.01f)
        {
            lastGroundedY = transform.position.y; // 更新最後落地高度
            Jump(); // 彈跳
        }

        // 掉下去超過 fallDeathThreshold 時，死亡
        if (transform.position.y < lastGroundedY - fallDeathThreshold)
        {
            gameManager.ShowGameOver();
        }

        //Debug.Log("force:" + m_rigidbody2D.velocity.y);
        if (m_rigidbody2D.velocity.y == 0f)
        {
            Jump();
        }
        if (m_rigidbody2D.velocity.y <= 0.01f)
        {
            if (isGrounded)
            {
                Jump();
            }
            碰撞器.enabled = true;
        }
        else
        {
            碰撞器.enabled = false;
        }

    }

    void Jump()
    {
        // 每次跳躍都重設 Y 軸速度，確保不會累加
        m_rigidbody2D.velocity = new Vector2(m_rigidbody2D.velocity.x, 0f);
        m_rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    void InitialJump()
    {
        Jump();
    }
}