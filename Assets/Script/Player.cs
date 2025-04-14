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

    private float lastGroundedY; // �̫�@�����b�a���ɪ�����
    public float fallDeathThreshold = 6f; // �����h�ֶZ���N���`

    public GameManager gameManager; // �� GameManager �i��

    private bool isGrounded = false;
    private Collider2D �I����;
    void Start()
    {
        m_rigidbody2D = GetComponent<Rigidbody2D>();
        �I���� = this.GetComponent<Collider2D>();
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

        if (isGrounded && m_rigidbody2D.velocity.y <= 0.01f)
        {
            lastGroundedY = transform.position.y; // ��s�̫Ḩ�a����
            Jump(); // �u��
        }

        // ���U�h�W�L fallDeathThreshold �ɡA���`
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
            �I����.enabled = true;
        }
        else
        {
            �I����.enabled = false;
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