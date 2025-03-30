using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject GrassPrefab; //�m��Prefab���ܼ�
    float GrassSpawnSpan = 5.0f; //�w�]�ɶ�����
    float GrassDelta = 0; //�{�b�w�g�ֿn���ɶ�

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GrassDelta += Time.deltaTime; // ���_�ֿn�ɶ�
        // �p�G�ֿn���ɶ��j��w�]���ɶ����סA�N�̾�Prefab���͹C������
        if (GrassDelta > GrassSpawnSpan)
        {
            GrassDelta = 0; // �N�ֿn�ɶ��k�s
            Instantiate(GrassPrefab, new Vector3(6, 5, 0), Quaternion.identity);// ���͹C������
        }

    }
}
