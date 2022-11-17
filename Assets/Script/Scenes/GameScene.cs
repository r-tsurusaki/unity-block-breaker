using UnityEngine;

public class GameScene : MonoBehaviour
{
    /// <summary>
    /// ステージ番号
    /// </summary>
    public StageNum stageNum;

    /// <summary>
    /// ゲームの状態
    /// </summary>
    private GameStatus gameStatus = GameStatus.Standby;

    /// <summary>
    /// オブジェクト
    /// </summary>
    public Ball[] balls;
    public Block[] blocks;

    /// <summary>
    /// UI
    /// </summary>
    public GameObject gameClearUI;
    public GameObject gameOverUI;

    void Update()
    {
        switch (this.gameStatus) {
            case GameStatus.Standby:
                // 画面がタッチされたらゲームスタートする
                if (Input.GetMouseButtonDown(0))
                {
                    this.GameStart();
                }
                break;

            case GameStatus.Playing:
                // Ballが全て消えていた場合はゲームオーバー処理を実行する
                if (this.DestroyAllBalls())
                {
                    this.GameOver();
                }

                // Blockが全て消えていた場合はゲームクリア処理を実行する
                if (this.DestroyAllBlocks())
                {
                    this.GameClear();
                }
                break;

            case GameStatus.GameClear:
            case GameStatus.GameOver:
                break;
        }
    }

    private bool DestroyAllBalls()
    {
        foreach(Ball ball in this.balls)
        {
            if (ball != null)
            {
                return false;
            }
        }
        return true;
    }


    private bool DestroyAllBlocks()
    {
        foreach (Block block in this.blocks)
        {
            if (block != null)
            {
                return false;
            }
        }
        return true;
    }

    private void GameStart()
    {
        foreach(Ball ball in this.balls)
        {
            ball.firstImpact();
        }
        this.gameStatus = GameStatus.Playing;
    }

    private void GameClear()
    {
        this.gameClearUI.SetActive(true);
        this.gameOverUI.SetActive(false);
        this.PauseAllBalls();
        this.gameStatus = GameStatus.GameClear;
        GameManager.StageClear(this.stageNum);
    }

    private void GameOver()
    {
        this.gameClearUI.SetActive(false);
        this.gameOverUI.SetActive(true);
        this.gameStatus = GameStatus.GameOver;
    }

    private void PauseAllBalls()
    {
        foreach(Ball ball in this.balls)
        {
            ball.pause();
        }
    }

    /// <summary>
    /// Menuに戻る処理
    /// </summary>
    public void LoadMenu()
    {
        this.gameStatus = GameStatus.Standby;
        GameManager.LoadSceneMenu();
    }

    /// <summary>
    /// GameRetryの処理
    /// </summary>
    public void GameRetry()
    {
        this.gameStatus = GameStatus.Standby;
        GameManager.LoadSceneStage1();
    }
}
