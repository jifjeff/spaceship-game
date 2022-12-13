using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public GameObject projectile;
    public ShipController shipController;
    public AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = this.GetComponent<Rigidbody2D>();

    }

    public void Spawn()
    {
        GameObject spawner = Instantiate(projectile, shipController.transform.position, Quaternion.identity);
        audio.Play();
             
    }
}
