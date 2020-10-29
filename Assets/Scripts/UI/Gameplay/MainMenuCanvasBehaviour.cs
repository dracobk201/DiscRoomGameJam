using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuCanvasBehaviour : MonoBehaviour
{
    public void SwitchScene()
    {
        SceneManager.LoadScene("Game 1");
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
            Application.Quit();
    }

}
