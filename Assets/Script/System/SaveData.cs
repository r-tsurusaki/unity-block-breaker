using System;

/// <summary>
/// セーブデータオブジェクト
/// </summary>
[Serializable]
public class SaveData
{
    /// <summary>
    /// ステージクリアフラグ
    /// </summary>
    public bool isCrearedStage1 { set; get; } = false;
}
