using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObstacleSpawner_c : MonoBehaviour
{
    public GameSettings_c gameSettings;
    public GameObject[] items;
    public GameObject[] obstacles;
    public Text statusText;
    private float spawnRate;
    private float spawnRadius;
    private float item_initialSpawnTime;
    private int i;
    private int enemiesRemaining;
    private int unlock;
    private bool isGameStarted;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(start(3.0f));
    }

    void Update()
    {
        
        i = Random.Range(0, obstacles.Length - unlock);

        if (enemiesRemaining <= 0)
        {
            CancelInvoke();
            gameSettings.hasFinishedLevel = true;
        }

    }
    void spawn()
    {
        addObstacles(enemiesRemaining, PlayerPrefs.GetInt("levelCounter"));
        if (enemiesRemaining % 50 == 0 && isGameStarted)
        {
            spawnRate -= 0.010f;
            if (spawnRate <= 0.15f)
            {
                spawnRate = 0.15f;
            }
        }      
        isGameStarted = true;
        enemiesRemaining--;
        GameObject spawner = Instantiate(obstacles[i], transform.position, Quaternion.identity);
        spawner.transform.position += Vector3.right * Random.Range(-spawnRadius, spawnRadius);
    }

    void spawnItem()
    {
        GameObject spawnerItem = Instantiate(items[0], transform.position, Quaternion.identity);
        spawnerItem.transform.position += Vector3.right * Random.Range(-spawnRadius, spawnRadius);
    }

    IEnumerator start(float time)
    {     
        startParams(PlayerPrefs.GetInt("levelCounter"));
        spawnRadius = 7.7f;
        isGameStarted = false;
        yield return new WaitForSeconds(time);
        statusText.text = "";
        InvokeRepeating("spawn", 1.0f, spawnRate);
        InvokeRepeating("spawnItem", item_initialSpawnTime, 140.0f);
    }

    private void addObstacles(int enemiesRemaining, int level)
    {
        if(level == 1)
        {
            if (enemiesRemaining <= 300)
            {
                unlock = 1;
            }
        }
        if (level == 2)
        {
            if (enemiesRemaining <= 350)
            {
                unlock = 0;
            }
        }
        
    }

    private void startParams(int level)
    {
        switch (level)
        {
            case 1:
                enemiesRemaining = 550;
                spawnRate = 0.6f;
                item_initialSpawnTime = 110.0f;
                statusText.color = Color.black;
                unlock = 2;
                statusText.text = "Fight off the mysterious beings";
                break;
            case 2:
                enemiesRemaining = 800;
                spawnRate = 0.45f;
                item_initialSpawnTime = 120.0f;
                statusText.color = Color.white;
                unlock = 1;
                statusText.text = "More mysterious beings appear";
                break;
            case 3:
                enemiesRemaining = 1750;
                spawnRate = 0.4f;
                item_initialSpawnTime = 80.0f;
                statusText.color = Color.red;
                unlock = 0;
                statusText.text = "It's their final stand!";
                break;
        }
    }
    //possible additions
    //Obstacle: hones in on the player's position
    //Obstacle: zig-zags
    //Obstacle: Debuffs the player temporarily (move speed, shot speed)
}
