using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameSettings : MonoBehaviour
{
    GUIStyle scoreFont = new GUIStyle();
    public GameObject panel;   
    public bool isPaused;
    private int getLives;
    public int score;
    private int finalScore;
    public GameObject resume;
    public GameObject mainMenuButton;
    public GameObject playAgain;
    public TMP_Text menuText;
    public AudioSource musicPlayer;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);
        resume.SetActive(true);
        mainMenuButton.SetActive(true);
        isPaused = false;
        Time.timeScale = 1;
        scoreFont.normal.textColor = Color.cyan;
        scoreFont.fontSize = 26; 
        score = 0;
        getLives = PlayerPrefs.GetInt("lives");
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
            StartCoroutine(wfs());
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
        finalScore = score;       
        menuText.text = $"Your Score: {finalScore.ToString()}";
    }

    public void playAgainPressed()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void toMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 300, 50), $"Score: {score.ToString("D9")}", scoreFont);
        GUI.Label(new Rect(Screen.width - 150, Screen.height - Screen.height / 12, 300, 50), $"Lives: {getLives.ToString()}", scoreFont);       
    }

    IEnumerator time_incrementScore()
    {
        score += 1;        
        yield return new WaitForSecondsRealtime(1.0f);
    }

    IEnumerator wfs()
    {
        yield return new WaitForSeconds(3.0f);
        GameOver();
        StopCoroutine(wfs());
    }

    public void playerRespawn()
    {
        Invoke("respawner", 3.0f);
        Invoke("isPausedFalse", 3.1f);
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

    public void isPausedTrue()
    {
        isPaused = true;
    }

    public void isPausedFalse()
    {
        isPaused = false;
    }
}
