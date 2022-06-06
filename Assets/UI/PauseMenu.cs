using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private string currentLevel;
    [SerializeField]private GameObject cinemachine;
    [SerializeField]private GameObject crosshair;
    public static bool _gameIsPaused = false;
    private InputManager inputManager;
    public GameObject pauseMenuUI;




    void Start()
    {
        inputManager = InputManager.Instance;
        currentLevel = SceneManager.GetActiveScene().name;
        Resume();
    }


    // Update is called once per frame
    void Update()
    {
        if(inputManager.GetMenu())
        {
            if(_gameIsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }

        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        _gameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        crosshair.SetActive(true);
        cinemachine.SetActive(true);
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        _gameIsPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        crosshair.SetActive(false);
        cinemachine.SetActive(false);
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(currentLevel);
        Resume();
    }
}
