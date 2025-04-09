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
        Invoke("InitialJump", 0.1f); // �קK��l���O�z�Z�A������D
    }

    void Update()
    {
        // ���k����
        float moveX = 0f;
        if (Input.GetKey(KeyCode.RightArrow))
            moveX = moveSpeed;
        else if (Input.GetKey(KeyCode.LeftArrow))
            moveX = -moveSpeed;

        m_rigidbody2D.velocity = new Vector2(moveX, m_rigidbody2D.velocity.y);

        // �ˬd�O�_�ۦa
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // �u������ۦa�B�ӥB�O���U�������A�A�~�|��
        if (isGrounded && m_rigidbody2D.velocity.y <= 0.01f)
        {
            Jump();
        }
    }

    void Jump()
    {
        // �C�����D�����] Y �b�t�סA�T�O���|�֥[
        m_rigidbody2D.velocity = new Vector2(m_rigidbody2D.velocity.x, 0f);
        m_rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    void InitialJump()
    {
        Jump();
    }
}
