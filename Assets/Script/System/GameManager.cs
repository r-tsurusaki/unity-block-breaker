using UnityEngine.SceneManagement;

public static class GameManager
{
    /// <summary>
    /// セーブデータオブジェクト
    /// </summary>
    public static SaveData saveData;

    static GameManager()
    {
        GameManager.saveData = new SaveData();
    }

    /// <summary>
    /// メニュー画面読み込み
    /// </summary>
    public static void LoadSceneMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    /// <summary>
    /// ステージ1読み込み
    /// </summary>
    public static void LoadSceneStage1()
    {
        SceneManager.LoadScene("Stage1");
    }

    /// <summary>
    /// ステージクリア処理
    /// </summary>
    /// <param name="stageNum">ステージ番号</param>
    public static void StageClear(StageNum stageNum)
    {
        switch (stageNum)
        {
            case StageNum.Stage1:
                GameManager.saveData.isCrearedStage1 = true;
                break;
        }
       
    }
}
