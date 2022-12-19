using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner_c3 : MonoBehaviour
{
    public GameObject projectile;
    public ShipController_c3 shipController;
    public new AudioSource audio;

    public void Spawn()
    {
        GameObject spawner = Instantiate(projectile, shipController.transform.position, Quaternion.identity);
        audio.Play();             
    }
}
