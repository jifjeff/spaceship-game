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
    private int level;

    private void Start()
    {
        level = 1;
        Time.timeScale = 1;
    }

    private void Update()
    {
        int.TryParse(livesSet.text, out int result);
        PlayerPrefs.SetInt("livesCounter", result);
    }

    public void campaignMode()
    {
        PlayerPrefs.SetInt("levelCounter", level);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void scoreMode()
    {
        PlayerPrefs.SetInt("levelCounter", level);
        SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings - 1);
    }

    public void quitGame()
    {
        Application.Quit();
    }
}