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

    private bool isGrounded = false;

    void Start()
    {
        m_rigidbody2D = GetComponent<Rigidbody2D>();
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

        // 只有當角色著地、而且是往下掉的狀態，才會跳
        if (isGrounded && m_rigidbody2D.velocity.y <= 0.01f)
        {
            Jump();
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
