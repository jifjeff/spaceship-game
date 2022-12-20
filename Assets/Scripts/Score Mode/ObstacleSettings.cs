using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObstacleSettings : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private int hp;
    private string clone = "(Clone)";
    public float moveSpeed;
    public float velocity;


    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.name == "brown" + clone)
        {
            hp = 0;
        }
        else if (gameObject.name == "green" + clone)
        {
            hp = 2;
        }
        else
        {
            hp = 1000;
        }

        rb2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb2d.AddForce(transform.up * velocity * -moveSpeed * Time.deltaTime);
        if (isOOB())
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (gameObject.tag == "Obstacle" && other.gameObject.tag == "Bullet" && gameObject.name != "red") //obstacle gets hit by bullet
        {
            if (hp <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                hp--;
            }
        }
        else if (gameObject.tag == "Item" && other.gameObject.tag == "Player") // obstacle destroyed when player hits item
        {
            Destroy(gameObject);
        }
        else if (other.gameObject.name == "Player" && gameObject.name != "red") //obstacle destroyed if the player hits it
        {
            Destroy(gameObject);
        }
    }

    private bool isOOB()
    {
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        return screenPosition.y < 0 - 50;
    }

}
