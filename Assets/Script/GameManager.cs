using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // 加入場景控制需要的命名空間

public class GameManager : MonoBehaviour
{
    [Header("平台生成設定")]
    public GameObject GrassPrefab;     // 放置平台的Prefab
    public float GrassSpawnSpan = 5.0f; // 每隔多久生成一個平台
    private float GrassDelta = 0f;     // 計時器累積時間

    [Header("UI與玩家")]
    public GameObject gameOverPanel;
    public GameObject winPanel;
    public Transform player;

    [Header("條件設定")]
    public float loseY = -5f;  // 玩家低於此值時 Game Over
    public float winY = 50f;   // 玩家高於此值時 過關

    void Start()
    {
        Time.timeScale = 1f; // 開始遊戲時保證是正常速度
        gameOverPanel.SetActive(false); // 關閉 UI 面板
        winPanel.SetActive(false);
    }

    void Update()
    {
        // 每幀累加時間
        GrassDelta += Time.deltaTime;

        // 當時間超過間隔時，生成新的平台
        if (GrassDelta > GrassSpawnSpan)
        {
            GrassDelta = 0f;

            // 設定平台生成位置
            float randomX = Random.Range(-5f, 5f); // 控制 X 軸範圍（你可以視畫面調整）
            float spawnY = player.position.y + 6f; // 平台出現在玩家正上方一段距離
            Instantiate(GrassPrefab, new Vector3(randomX, spawnY, 0), Quaternion.identity);
        }

        // 判斷是否 Game Over
        if (player.position.y < loseY)
        {
            ShowGameOver();
        }

        // 判斷是否過關
        if (player.position.y > winY)
        {
            ShowWin();
        }
    }

    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f; // 暫停遊戲
    }

    public void ShowWin()
    {
        winPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}