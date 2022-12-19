using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObstacleSpawner_c2 : MonoBehaviour
{
    public GameSettings_c2 gameSettings;
    public GameObject[] items;
    public GameObject[] obstacles;
    public Text statusText;
    private float spawnRate;
    private float item_initialSpawnTime;
    private int unlock;
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
        i = Random.Range(0, obstacles.Length - unlock);

        if (enemiesRemaining <= 0)
        {
            CancelInvoke();
            gameSettings.hasFinishedLevel = true;
        }

    }
    void spawn()
    {
        addObstacles(enemiesRemaining);
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
        enemiesRemaining = 650;
        spawnRate = 0.4f;
        item_initialSpawnTime = 110.0f;
        unlock = 1;
        statusText.color = Color.white;
        statusText.text = "More mysterious beings appear";
        yield return new WaitForSeconds(time);
        statusText.text = "";
        InvokeRepeating("spawn", 1.0f, spawnRate);
        InvokeRepeating("spawnItem", item_initialSpawnTime, 140.0f);
    }

    private void addObstacles(int enemiesRemaining)
    {
        if (enemiesRemaining <= 350)
        {
            unlock = 0;
        }
    }

    //possible additions
    //Obstacle: hones in on the player's position
    //Obstacle: zig-zags
    //Obstacle: Debuffs the player temporarily (move speed, shot speed)

}
