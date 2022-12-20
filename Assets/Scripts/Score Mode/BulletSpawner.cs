using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletSprite;
    public ShipController shipController;
    public AudioSource shootingSound;

    public void Spawn()
    {
        GameObject spawner = Instantiate(bulletSprite, shipController.transform.position, Quaternion.identity);
        shootingSound.Play();             
    }
}
