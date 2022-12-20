using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public Button campaign;
    public TMP_Text campaignText;
    public Button scoreBtn;
    public TMP_Text scoreText;
    public Button exit;
    public TMP_Text exitText;
    public TMP_InputField livesSet;

    private void Start()
    {
        Time.timeScale = 1;
    }

    private void Update()
    {
        int.TryParse(livesSet.text, out int result);
        PlayerPrefs.SetInt("livesCounter", result);
    }

    public void campaignMode()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void scoreMode()
    {
        SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings - 1);
    }

    public void quitGame()
    {
        Application.Quit();
    }
}