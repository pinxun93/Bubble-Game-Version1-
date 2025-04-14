using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab;     // ��A�� Grass prefab �i��
    public Transform player;              // �쨤��i��
    public float spawnYDistance = 5f;
    public float platformSpacingY = 2.5f;
    public float platformRangeX = 2.5f;

    [Header("�ͦ��ɶ��]�w")]
    public float initialDelay = 3f;   // �Ĥ@���ͦ�����ɶ�
    public float repeatRate = 5f;     // �C�X��ͦ��@��

    private float highestY = 0f;
    private List<GameObject> platforms = new List<GameObject>();

    void Start()
    {
        highestY = player.position.y;

        // ���ͪ�l���x
        for (int i = 0; i < 10; i++)
        {
            SpawnPlatform(i * platformSpacingY);
        }
        InvokeRepeating("newPlatform", 3, 5);
    }

    void newPlatform()
    {
        // ���a���W���A���ͷs���x
        if (player.position.y + spawnYDistance > highestY)
        {
            highestY += platformSpacingY;
            SpawnPlatform(highestY);
            //print("Platform by PlatformSpawner (UPDATE)");

        }
    }

    void Update()
    {
        // �R���ӧC�����x
        platforms.RemoveAll(p =>
        {
            if (p.transform.position.y + 10f < player.position.y)
            {
                Destroy(p);
                return true;
            }
            return false;
        });
    }

    void SpawnPlatform(float y)
    {
        float x = Random.Range(-platformRangeX, platformRangeX);
        Vector3 pos = new Vector3(x, y, 0);
        GameObject newPlat = Instantiate(platformPrefab, pos, Quaternion.identity);
        platforms.Add(newPlat);
        //print("Platform by PlatformSpawner");
    }
}
