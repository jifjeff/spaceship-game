using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObstacleSpawner : MonoBehaviour
{
    public GameSettings gameSettings;
    public GameObject[] items;
    public GameObject[] obstacles;
    public Text statusText;
    private float spawnRate;
    private int unlock;
    private int i;

    // Start is called before the first frame update
    void Start()
    {
        unlock = 2;
        spawnRate = 0.6f;
        statusText.color = Color.black;
        StartCoroutine(wfs(3.0f));
        
    }

    private void Update()
    {
        if (gameSettings.score % 8000 == 0)
        {
            spawnRate -= 0.010f;
            if (spawnRate <= 0.15f)
            {
                spawnRate = 0.15f;
            }
        }
        i = Random.Range(0, obstacles.Length - unlock);
    }
    void spawn()
    {
        addObstacles(gameSettings.score);      
        GameObject spawner = Instantiate(obstacles[i], transform.position, Quaternion.identity);
        spawner.transform.position += Vector3.right * Random.Range(-8.5f, 8.5f);
    }

    void spawnItem()
    {
        GameObject spawnerItem = Instantiate(items[0], transform.position, Quaternion.identity);
        spawnerItem.transform.position += Vector3.right * Random.Range(-8.5f, 8.5f);
    }

    IEnumerator wfs(float time)
    {
        statusText.text = "Survive for as long as you can!";
        yield return new WaitForSeconds(time);
        statusText.text = "";
        InvokeRepeating("spawn", 1.0f, spawnRate);
        InvokeRepeating("spawnItem", 120.0f, 160.0f);
    }

    private void addObstacles(int score)
    {
        if (score >= 150000)
        {
            unlock = 0;
        }
        else if (score >= 50000)
        {
            unlock = 1;
        }
    }
}
