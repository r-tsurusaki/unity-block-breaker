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
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        // OutLineに当たったら
        if (collision.gameObject.tag.Equals("OutLine"))
        {
            // このオブジェクトを破棄する
            Destroy(this.gameObject);
        }
    }

    /// <summary>
    /// オブジェクトの動きを停止する
    /// </summary>
    public void pause()
    {
        Time.timeScale = 0f;
    }

    /// <summary>
    /// スタート時に発射する処理
    /// </summary>
    public void firstImpact()
    {
        Time.timeScale = 1f;
        this.myRigidbody.AddForce(new Vector2(this.speedX, this.speedY));
    }

    /// <summary>
    /// ランダムに発射する処理
    /// </summary>
    public void RandomImpact()
    {
        Time.timeScale = 1f;
        this.myRigidbody.AddForce(new Vector2(this.speedX * this.RandomInt(), this.speedY * this.RandomInt()));
    }

    private int RandomInt()
    {
        return Random.Range(0, 2) == 0 ? 1 : -1;
    }
}
