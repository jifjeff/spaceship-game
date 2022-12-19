using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObstacleSpawner_c3 : MonoBehaviour
{
    public GameSettings_c3 gameSettings;
    public GameObject[] items;
    public GameObject[] obstacles;
    public Text statusText;
    private float spawnRate;
    private float item_initialSpawnTime;
    private int i;
    private int enemiesRemaining;

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
        i = Random.Range(0, obstacles.Length - 0);

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
        enemiesRemaining = 1500;
        spawnRate = 0.4f;
        item_initialSpawnTime = 100.0f;
        statusText.color = Color.red;
        statusText.text = "It's their final stand!";
        yield return new WaitForSeconds(time);
        statusText.text = "";
        InvokeRepeating("spawn", 1.0f, 0.3f);
        InvokeRepeating("spawnItem", item_initialSpawnTime, 160.0f);
    }

    //possible additions
    //Obstacle: hones in on the player's position
    //Obstacle: zig-zags
    //Obstacle: Debuffs the player temporarily (move speed, shot speed)

}
