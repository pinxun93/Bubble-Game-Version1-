using UnityEngine;

public class Grass : MonoBehaviour
{
    public float breakDelay = 0.3f; // 延遲多久後破裂
    private bool isStepped = false; // 確保只踩一次

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 確認是玩家踩上來，而且還沒踩過
        if (!isStepped && collision.gameObject.CompareTag("Player"))
        {
            isStepped = true;
            Invoke("BreakPlatform", breakDelay);
        }
    }

    void BreakPlatform()
    {
        // 這裡你也可以播放破裂動畫或音效
        Destroy(gameObject);
    }
}
