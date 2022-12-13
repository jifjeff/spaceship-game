using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnObstacles : MonoBehaviour
{
    public GameObject Obstacle;
    public Text statusText;
    // Start is called before the first frame update
    void Start()
    {
        statusText.color = Color.white;
        StartCoroutine(wfs(3.0f));      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawn()
    {
        GameObject spawner = Instantiate(Obstacle, transform.position, Quaternion.identity);
        spawner.transform.position += Vector3.right * Random.Range(-8.5f, 8.5f);
    }

    IEnumerator wfs(float time)
    {
        statusText.text = "Survive for as long as you can!";
        yield return new WaitForSeconds(time);
        statusText.text = "";
        InvokeRepeating("spawn", 1.0f, 0.7f);
    }
}
