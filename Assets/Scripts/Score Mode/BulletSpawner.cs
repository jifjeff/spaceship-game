using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject projectile;
    public ShipController shipController;
    public new AudioSource audio;

    public void Spawn()
    {
        GameObject spawner = Instantiate(projectile, shipController.transform.position, Quaternion.identity);
        audio.Play();             
    }
}
