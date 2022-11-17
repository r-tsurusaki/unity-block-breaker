using UnityEngine;

public class Block : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Ballが衝突した場合は自オブジェクトを破棄する
        if (collision.gameObject.name.Equals("Ball"))
        {
            Destroy(this.gameObject);        
        }
    }
}
