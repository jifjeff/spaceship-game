using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameSettings : MonoBehaviour
{
    GUIStyle scoreFont = new GUIStyle();
    GUIStyle livesFont = new GUIStyle();
    public GameObject panel;
    public GameObject resume;
    public GameObject playAgain;
    public GameObject mainMenuButton;
    public GameObject player;
    public GameObject obstacleSpawner;
    public TMP_Text menuText;
    public AudioSource musicPlayer;
    private int getLives;
    public int score;
    public bool hasFinishedLevel;
    public bool isPaused;
    public bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);
        resume.SetActive(true);
        mainMenuButton.SetActive(true);
        isPaused = false;
        Time.timeScale = 1;
        scoreFont.normal.textColor = Color.cyan; 
        scoreFont.fontSize = 60;
        livesFont.fontSize = scoreFont.fontSize;
        getLives = 1;
        livesFont.normal.textColor = scoreFont.normal.textColor;    
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!isPaused)
        {
            StartCoroutine(time_incrementScore());
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            Pause();     
        }
        
        if (getLives <= 0)
        {
            StartCoroutine(triggerGameOver());
        }

        if (getLives == 1)
        {
            livesFont.normal.textColor = Color.red;
        }
    }

    public void Pause()
    {
        panel.SetActive(true);
        menuText.text = "Game Paused";
        isPaused = true;
        musicPlayer.Pause();
        Time.timeScale = 0;
    }

    public void Resume()
    {
        panel.SetActive(false);
        isPaused = false;       
        musicPlayer.Play();
        Time.timeScale = 1;
    }

    public void GameOver()
    {    
        panel.SetActive(true);
        resume.SetActive(false);
        playAgain.SetActive(true);
        musicPlayer.Stop();
        isPaused = true;
        Time.timeScale = 0;      
        menuText.text = $"Your Score: {score.ToString()}";
    }

    public void playAgainPressed()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void mainMenuPressed()
    {
        SceneManager.LoadScene(0);
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 300, 50), $"{score.ToString("D9")}", scoreFont);
        GUI.Label(new Rect(Screen.width - 260, Screen.height - Screen.height / 12, 300, 50), $"Lives: {getLives.ToString()}", livesFont);       
    }

    IEnumerator time_incrementScore()
    {
        score += 1;        
        yield return new WaitForSeconds(1.0f);
    }

    IEnumerator triggerGameOver()
    {
        yield return new WaitForSeconds(3.0f);
        GameOver();
    }

    public void playerRespawn()
    {
        Invoke("respawner", 3.0f);
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
    }

    public void subtractLife()
    {
        getLives -= 1;
    }
}
