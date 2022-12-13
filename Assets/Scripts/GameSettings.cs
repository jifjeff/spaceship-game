using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSettings : MonoBehaviour
{
    GUIStyle scoreFont = new GUIStyle();
    GUIStyle livesCounter = new GUIStyle();
    public int score;
    public int lives;

    // Start is called before the first frame update
    void Start()
    {
        scoreFont.normal.textColor = Color.cyan;
        scoreFont.fontSize = 26; 
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(time_incrementScore());
    }

    public void Play()
    {
        
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void Resume()
    {
        Time.timeScale = 1;
    }

    private void OnGUI()
    {
        Vector2 lowerRightScreen = new Vector2(Screen.width, 0);
        Vector2 screenPosition = Camera.main.ScreenToWorldPoint(Vector2.zero);
        GUI.Label(new Rect(10, 10, 300, 50), $"Score: {score.ToString("D9")}", scoreFont);
        GUI.Label(new Rect(Screen.width - 150, screenPosition.y, 300, 50), $"Lives: ", scoreFont);
        
    }

    IEnumerator time_incrementScore()
    {
        score += 1;        
        yield return new WaitForSecondsRealtime(1.0f);
    }
}
