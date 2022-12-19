using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObstacleSpawner : MonoBehaviour
{
    public GameSettings gameSettings;
    public GameObject Obstacle;
    public GameObject[] items;
    //public GameObject[] obstacles;
    public Text statusText;
    private float spawnRate;
    // Start is called before the first frame update
    void Start()
    {
        spawnRate = 0.6f;
        statusText.color = Color.black;
        StartCoroutine(wfs(3.0f));      
    }

    private void Update()
    {
        if (gameSettings.score % 7500 == 0)
        {
            spawnRate -= 0.010f;
        }
    }
    void spawn()
    {
<<<<<<< Updated upstream:Assets/Scripts/ObstacleSpawner.cs
        //int i = Random.Range(0, obstacles.Length);
        GameObject spawner = Instantiate(Obstacle, transform.position, Quaternion.identity);
        spawner.transform.position += Vector3.right * Random.Range(-8.5f, 8.5f);
=======
        addObstacles(gameSettings.score);      
        GameObject spawner = Instantiate(obstacles[i], transform.position, Quaternion.identity);
        spawner.transform.position += Vector3.right * Random.Range(-8.4f, 8.4f);
>>>>>>> Stashed changes:Assets/Scripts/Score Mode/ObstacleSpawner.cs
    }

    void spawnItem()
    {
        GameObject spawnerItem = Instantiate(items[0], transform.position, Quaternion.identity);
        spawnerItem.transform.position += Vector3.right * Random.Range(-8.4f, 8.4f);
    }

    IEnumerator wfs(float time)
    {
        statusText.text = "Survive for as long as you can!";
        yield return new WaitForSeconds(time);
        statusText.text = "";
        InvokeRepeating("spawn", 1.0f, spawnRate);
<<<<<<< Updated upstream:Assets/Scripts/ObstacleSpawner.cs
        InvokeRepeating("spawnItem", 5.0f, 160.0f);
=======
        InvokeRepeating("spawnItem", 120.0f, 160.0f);
    }

    private void addObstacles(int score)
    {
        if (score >= 200000)
        {
            unlock = 0;
        }
        else if (score >= 50000)
        {
            unlock = 1;
        }
>>>>>>> Stashed changes:Assets/Scripts/Score Mode/ObstacleSpawner.cs
    }
}
