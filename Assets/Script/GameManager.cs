using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject GrassPrefab; //置放Prefab的變數
    float GrassSpawnSpan = 5.0f; //預設時間長度
    float GrassDelta = 0; //現在已經累積的時間

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GrassDelta += Time.deltaTime; // 不斷累積時間
        // 如果累積的時間大於預設的時間長度，就依據Prefab產生遊戲物件
        if (GrassDelta > GrassSpawnSpan)
        {
            GrassDelta = 0; // 將累積時間歸零
            Instantiate(GrassPrefab, new Vector3(6, 5, 0), Quaternion.identity);// 產生遊戲物件
        }

    }
}
