using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSettings : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private int hp;
    public float moveSpeed;
    public float velocity;
    // Start is called before the first frame update
    void Start()
    {
        hp = 3;
        moveSpeed = 15.0f;
        velocity = 2.0f;
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        this.rb2d.AddForce(transform.up * velocity * -moveSpeed * Time.deltaTime);  
        if (isOOB())
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bullet")
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
    }

    private bool isOOB()
    {
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        return screenPosition.y < 0 - 50;
    }
}
