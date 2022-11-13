using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScene : MonoBehaviour
{
    public Ball ball;
    public Block[] blocks;

    public GameObject gameOverUI;
    public GameObject gameClearUI;

    private bool isGameClear = false;

    void Update()
    {
        if (this.isGameClear)
        {
            return;
        }

        // Blockが全て消えていた場合はゲームクリア処理を実行する
        if (this.DestroyAllBlocks())
        {
            this.GameClear();
        }
    }

    private bool DestroyAllBlocks()
    {
        foreach(Block block in this.blocks)
        {
            if (block != null)
            {
                return false;
            }
        }
        return true;
    }

    /// <summary>
    /// ゲームクリアの処理
    /// </summary>
    private void GameClear()
    {
        this.gameClearUI.SetActive(true);
        this.gameOverUI.SetActive(false);
        this.ball.stop();
        this.isGameClear = true;
    }

    /// <summary>
    /// ゲームオーバーの処理
    /// </summary>
    public void GameOver()
    {
        this.gameClearUI.SetActive(false);
        this.gameOverUI.SetActive(true);
    }

    /// <summary>
    /// GameRetryの処理
    /// </summary>
    public void GameRetry()
    {
        SceneManager.LoadScene("Game");
    }
}
