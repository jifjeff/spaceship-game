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
        if (enemiesRemaining % 50 == 0 && enemiesRemaining != 500)
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
        spawner.transform.position += Vector3.right * Random.Range(-8.5f, 8.5f);
    }

    void spawnItem()
    {
        GameObject spawnerItem = Instantiate(items[0], transform.position, Quaternion.identity);
        spawnerItem.transform.position += Vector3.right * Random.Range(-8.5f, 8.5f);
    }

    IEnumerator start(float time)
    {
        enemiesRemaining = 550;
        spawnRate = 0.5f;
        item_initialSpawnTime = 120.0f;
        unlock = 2;
        statusText.color = Color.black;
        statusText.text = "Fight back the mysterious beings";
        yield return new WaitForSeconds(time);
        statusText.text = "";

        InvokeRepeating("spawn", 1.0f, 0.5f);
        InvokeRepeating("spawnItem", item_initialSpawnTime, 160.0f);
    }

    private void addObstacles(int enemiesRemaining)
    {
        if (enemiesRemaining <= 250)
        {
            unlock = 1;
        }
    }
}
