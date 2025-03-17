using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D m_rigidbody2D; // �إߤ@��2D�����ܼ�

    public float moveSpeed = 1.0f;     // �إߤ@�Ӥ��}(public)�B�I��moveSpeed

    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody2D = GetComponent<Rigidbody2D>(); // �C���@����A���o�~�P�H������
    }

    // Update is called once per frame
    void Update()
    {
        // �p�G���U��L�k��V��A���~�P�H��X�b����1
        if (Input.GetKey(KeyCode.RightArrow))
        {
            m_rigidbody2D.velocity = new Vector3(moveSpeed, 0, 0);
        }
        // �p�G���U��L����V��A���~�P�H��X�b����-1�A�]�N�O��������1
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            m_rigidbody2D.velocity = new Vector3(-moveSpeed, 0, 0);
        }
        // �p�G�k��V��u�Ρv����V��A�Q�u��}�v���ɭԡA�N���Ҧ��t�׳��k0
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            m_rigidbody2D.velocity = new Vector3(0, 0, 0);
        }
        // �p�G���U��L�ť���A���~�P�H��Y�b����1�A�]�N�O���W����1
        if (Input.GetKey(KeyCode.Space))
        {
            m_rigidbody2D.velocity = new Vector3(0, moveSpeed, 0);
        }
    }
}