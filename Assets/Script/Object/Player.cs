using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D myRigidbody;

    public float playerSpeed = 10;

    private bool buttonLeftDownFlag = false;
    private bool buttonRightDownFlag = false;

    // Start is called before the first frame update
    void Start()
    {
        this.myRigidbody = this.gameObject.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector2 force = Vector2.zero;

        // 左キーの動作
        if (Input.GetKey(KeyCode.LeftArrow) || this.buttonLeftDownFlag)
        {
            force = new Vector2(this.playerSpeed * -1, 0);
        }

        // 右キーの動作
        // 
        if (Input.GetKey(KeyCode.RightArrow) || this.buttonRightDownFlag)
        {
            force = new Vector2(this.playerSpeed, 0);
        }

        this.myRigidbody.MovePosition(this.myRigidbody.position + force * Time.fixedDeltaTime);
    }

    /// <summary>
    /// Leftボタンをタップ
    /// </summary>
    public void OnLeftButtonDown()
    {
        this.buttonLeftDownFlag = true;
    }

    /// <summary>
    /// Leftボタンをアンタップ
    /// </summary>
    public void OnLeftButtonUp()
    {
        this.buttonLeftDownFlag = false;
    }

    /// <summary>
    /// Rightボタンをタップ
    /// </summary>
    public void OnRightButtonDown()
    {
        this.buttonRightDownFlag = true;
    }

    /// <summary>
    /// Rightボタンをアンタップ
    /// </summary>
    public void OnRightButtonUp()
    {
        this.buttonRightDownFlag = false;
    }
}
