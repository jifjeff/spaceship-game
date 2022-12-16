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
        //int i = Random.Range(0, obstacles.Length);
        GameObject spawner = Instantiate(Obstacle, transform.position, Quaternion.identity);
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
        InvokeRepeating("spawnItem", 5.0f, 160.0f);
    }
}
