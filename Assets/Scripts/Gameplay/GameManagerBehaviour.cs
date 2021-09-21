using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerBehaviour : MonoBehaviour
{
    public Canvas gamePauseScreen = null;

    private bool _gamePaused = false;

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gamePauseScreen.gameObject.SetActive(!gamePauseScreen.gameObject.activeSelf);
            _gamePaused = gamePauseScreen.gameObject.activeSelf;
            if (_gamePaused)
                Time.timeScale = 0.0f;
            else
                Time.timeScale = 1.0f;
        }
    }

    public void restartGame()
    {
        SceneManager.LoadScene(0);

        _gamePaused = false;
        Time.timeScale = 1.0f;
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
