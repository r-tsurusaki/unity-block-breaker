using UnityEngine;

public class TitleScene : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameManager.LoadSceneMenu();
        }    
    }
}
