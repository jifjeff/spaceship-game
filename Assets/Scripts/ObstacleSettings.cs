using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//public class ObstacleStats
//{
//    public int hp;
//    public float moveSpeed;

//    public ObstacleStats(int hp, float moveSpeed)
//    {
//        this.hp = hp;
//        this.moveSpeed = moveSpeed;
//    }
//}

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
        if (gameObject.name == "AsterBig1" +clone)
        {
            hp = 3;
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
        if (gameObject.tag == "Obstacle" && other.gameObject.tag == "Bullet") //obstacle gets hit by bullet
        {
            if (hp > 0)
            {
                hp -= 1;
            }
            else
            {
                Destroy(gameObject);
            }
        }
        else if(gameObject.tag == "Item" && other.gameObject.tag == "Player") // destroyed when player hits item
        {
            Destroy(gameObject);
        }
        else if (other.gameObject.name == "Player") //automatically destroys it if player hits it
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
