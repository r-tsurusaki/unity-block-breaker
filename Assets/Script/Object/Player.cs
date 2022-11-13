using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D myRigidbody;

    public float playerSpeed = 10;

    // Start is called before the first frame update
    void Start()
    {
        this.myRigidbody = this.gameObject.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector2 force = Vector2.zero;

        // 左キーの動作
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            force = new Vector2(this.playerSpeed * -1, 0);
        }

        // 右キーの動作
        // 
        if (Input.GetKey(KeyCode.RightArrow))
        {
            force = new Vector2(this.playerSpeed, 0);
        }

        this.myRigidbody.MovePosition(this.myRigidbody.position + force * Time.fixedDeltaTime);
    }
}
