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
    private float item_initialSpawnTime;
    private int i;
    private int enemiesRemaining;
    private int unlock;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(start(3.0f));
    }

    void Update()
    {
        if (enemiesRemaining % 50 == 0 && enemiesRemaining != 650)
        {
            spawnRate -= 0.010f;
            if (spawnRate <= 0.15f)
            {
                spawnRate = 0.15f;
            }
        }
        i = Random.Range(0, obstacles.Length - unlock);

        if (enemiesRemaining <= 0)
        {
            CancelInvoke();
            gameSettings.hasFinishedLevel = true;
        }

    }
    void spawn()
    {
        enemiesRemaining--;
        GameObject spawner = Instantiate(obstacles[i], transform.position, Quaternion.identity);
        spawner.transform.position += Vector3.right * Random.Range(-8.4f, 8.4f);
    }

    void spawnItem()
    {
        GameObject spawnerItem = Instantiate(items[0], transform.position, Quaternion.identity);
        spawnerItem.transform.position += Vector3.right * Random.Range(-8.4f, 8.4f);
    }

    IEnumerator start(float time)
    {     
        startParams(PlayerPrefs.GetInt("levelCounter"));
        Debug.Log(enemiesRemaining.ToString());
        Debug.Log(spawnRate.ToString());       
        yield return new WaitForSeconds(time);
        statusText.text = "";
        InvokeRepeating("spawn", 1.0f, 0.6f);
        InvokeRepeating("spawnItem", item_initialSpawnTime, 160.0f);
    }


    private void addObstacles(int enemiesRemaining, int level)
    {
        if (enemiesRemaining <= 250 && level == 1)
        {
            unlock = 1;
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
                enemiesRemaining = 750;
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
