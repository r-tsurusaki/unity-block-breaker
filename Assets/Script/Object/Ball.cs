using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D myRigidbody;

    public GameScene gameScene;

    public float speedX = 100;
    public float speedY = 100;

    // Start is called before the first frame update
    void Start()
    {
        this.myRigidbody = this.gameObject.GetComponent<Rigidbody2D>();

        // 初期動作を与える
        Vector2 force = new Vector2(this.speedX, this.speedY);
        this.myRigidbody.AddForce(force);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        // OutLineに当たったら
        if (collision.gameObject.tag.Equals("OutLine"))
        {
            // このオブジェクトを破棄する
            Destroy(this.gameObject);

            // ゲームオーバー処理の実行
            this.gameScene.GameOver();
        }
    }

    /// <summary>
    /// オブジェクトの動きを停止する
    /// </summary>
    public void stop()
    {
        this.myRigidbody.velocity = Vector2.zero;
    }
}
