using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameSettings_c : MonoBehaviour
{
    GUIStyle scoreFont = new GUIStyle();
    GUIStyle livesFont = new GUIStyle();  
    public GameObject panel;
    public GameObject obstacleSpawner;
    public GameObject resume;
    public GameObject mainMenuButton;
    public GameObject playAgain;
    public GameObject toNextLevel;
    public TMP_Text menuText;
    public AudioSource musicPlayer;
    public GameObject player;
    public bool isDead;   
    public bool hasFinishedLevel;
    private int getLives;
    private int getLevelNumber;

    // Start is called before the first frame update
    void Start()
    {
        getLevelNumber = PlayerPrefs.GetInt("levelCounter");
        getLives = PlayerPrefs.GetInt("livesCounter");
        normalLayer();
        panel.SetActive(false);
        resume.SetActive(true);
        mainMenuButton.SetActive(true);
        toNextLevel.SetActive(false);
        Time.timeScale = 1;
        isDead = false;
        hasFinishedLevel = false;
        startParams(getLevelNumber);
        scoreFont.fontSize = 60;
        livesFont.fontSize = scoreFont.fontSize;        
        livesFont.normal.textColor = scoreFont.normal.textColor;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Pause();     
        }

        if (getLives == 1)
        {
            livesFont.normal.textColor = Color.red;
        }

        if (getLives <= 0)
        {
            StartCoroutine(gameOverCoro());
        }

        if(hasFinishedLevel)
        {
            
            StartCoroutine(levelFinishedCoro());
        }
    }
    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 300, 50), $"Level {getLevelNumber.ToString()}", scoreFont);
        GUI.Label(new Rect(Screen.width - 260, Screen.height - Screen.height / 12, 300, 50), $"Lives:  {getLives.ToString()}", livesFont);
    }

    public void Pause()
    {
        panel.SetActive(true);
        menuText.text = "Game Paused";
        musicPlayer.Pause();
        Time.timeScale = 0;
    }

    public void Resume()
    {
        panel.SetActive(false);
        musicPlayer.Play();
        Time.timeScale = 1;
    }

    public void GameOver()
    {        
        panel.SetActive(true);
        resume.SetActive(false);
        playAgain.SetActive(true);
        Time.timeScale = 0;      
        menuText.text = "Game Over";
    }

    public void finishedLevel()
    {
        panel.SetActive(true);
        resume.SetActive(false);
        toNextLevel.SetActive(true);        
        musicPlayer.Stop();
        Time.timeScale = 0;
        menuText.text = "There's still more to go";
    }

    public void playAgainPressed()
    {
        SceneManager.LoadScene(1);
    }

    public void continuePressed()
    {
        PlayerPrefs.SetInt("livesCounter", getLives);
        PlayerPrefs.SetInt("levelCounter", getLevelNumber + 1);
        SceneManager.LoadScene("CampaignMode_2");
    }

    public void mainMenuPressed()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
 
    IEnumerator gameOverCoro()
    {
        musicPlayer.Stop();
        yield return new WaitForSeconds(3.0f);
        GameOver();
    }

    IEnumerator levelFinishedCoro()
    {
        musicPlayer.Stop();
        yield return new WaitForSeconds(7.0f);
        PlayerPrefs.SetInt("currentLives", getLives);
        finishedLevel();
    }

    public void playerRespawn()
    {
        isDead = true;
        Invoke("respawner", 3.2f);       

    }

    private void respawner()
    {
        player.transform.position = player.transform.position;
        player.layer = LayerMask.NameToLayer("Player Invulnerability");
        player.SetActive(true);
        Invoke("normalLayer", 3.0f);
    }

    private void normalLayer()
    {
        player.layer = LayerMask.NameToLayer("Player");
        isDead = false;
    }

    public void subtractLife()
    {
        getLives -= 1;
        
    }
    public void isDeadFalse()
    {
        isDead = false;
    }

    private void startParams(int level)
    {
        switch (level)
        {
            case 1:
                scoreFont.normal.textColor = Color.green;
                break;
            case 2:
                scoreFont.normal.textColor = Color.gray;
                break;
            case 3:
                scoreFont.normal.textColor = new Color(255, 165, 0);
                break;
        }
    }
}
