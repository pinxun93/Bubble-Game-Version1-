using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab;     // 拖你的 Grass prefab 進來
    public Transform player;              // 拖角色進來
    public float spawnYDistance = 5f;
    public float platformSpacingY = 2.5f;
    public float platformRangeX = 2.5f;

    [Header("生成時間設定")]
    public float initialDelay = 3f;   // 第一次生成延遲時間
    public float repeatRate = 5f;     // 每幾秒生成一次

    private float highestY = 0f;
    private List<GameObject> platforms = new List<GameObject>();

    void Start()
    {
        highestY = player.position.y;

        // 產生初始平台
        for (int i = 0; i < 10; i++)
        {
            SpawnPlatform(i * platformSpacingY);
        }
        InvokeRepeating("newPlatform", 3, 5);
    }

    void newPlatform()
    {
        // 玩家往上爬，產生新平台
        if (player.position.y + spawnYDistance > highestY)
        {
            highestY += platformSpacingY;
            SpawnPlatform(highestY);
            //print("Platform by PlatformSpawner (UPDATE)");

        }
    }

    void Update()
    {
        // 刪除太低的平台
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
