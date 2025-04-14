using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("UI與玩家")]
    public GameObject gameOverPanel;
    public GameObject winPanel;
    public Transform player;

    [Header("條件設定")]
    public float winY = 50f;
    public float fallDistanceToFail = 6f; // 掉落幾單位距離算失敗

    [Header("地面偵測")]
    public Transform groundCheck; // 設為角色腳下的空物件
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    private float lastSafeY;
    private bool gameEnded = false;

    void Start()
    {
        Time.timeScale = 1f;
        gameOverPanel.SetActive(false);
        winPanel.SetActive(false);

        lastSafeY = player.position.y;
    }

    void Update()
    {
        if (gameEnded) return;

        //如果腳底碰到地面，就更新安全位置
        bool isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        if (isGrounded)
        {
            lastSafeY = player.position.y;
        }

        //掉落過遠 → 判定 Game Over
        if (player.position.y < lastSafeY - fallDistanceToFail)
        {
            ShowGameOver();
        }

        // 過關判定
        if (player.position.y > winY)
        {
            ShowWin();
        }
    }

    public void ShowGameOver()
    {
        gameEnded = true;
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ShowWin()
    {
        gameEnded = true;
        winPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
