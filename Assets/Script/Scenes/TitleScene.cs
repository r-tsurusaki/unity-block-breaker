using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScene : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            this.GameStart();
        }
    }

    public void GameStart()
    {
        SceneManager.LoadScene("Game");
    }
}
