using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private Button ResumeButton;
    [SerializeField] private Button MainMenuButton;
    [SerializeField] private Button QuitButton;
    [SerializeField] private GameObject Panel;

    private void Awake()
    {
        Panel.SetActive(false);
        ResumeButton.onClick.AddListener(Resume);
        MainMenuButton.onClick.AddListener(MainMenu);
        QuitButton.onClick.AddListener(Quit);
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Panel.SetActive(!Panel.activeSelf);
        }
    }

    private void Resume()
    {
        Panel.SetActive(false);
    }
    private void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    private void Quit()
    {
        Application.Quit();
    }
}
