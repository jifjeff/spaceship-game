using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private bool moveleft;
    private bool moveright;
    private bool moveup;
    private bool movedown;
    public float moveSpeed = 8.0f;
    private bool canShoot;
    private bool canMove;
    public float delayTime;
    public GameObject spaceship;
    public GameSettings gameSettings;
    public BulletSpawner bulletSpawner;
    

    // Start is called before the first frame update
    void Start()
    {
        delayTime = 0.2f;
        Time.timeScale = 1;
        canShoot = true;
        canMove = true;
        rb2d = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveleft = Input.GetKey(KeyCode.LeftArrow);
        moveright = Input.GetKey(KeyCode.RightArrow);
        moveup = Input.GetKey(KeyCode.UpArrow);
        movedown = Input.GetKey(KeyCode.DownArrow);    
    }

    void FixedUpdate()
    {
        if (canMove)
        {
            if (moveleft)
            {
                rb2d.AddForce(transform.right * -moveSpeed * Time.fixedDeltaTime);
            }

            if (moveright)
            {
                rb2d.AddForce(transform.right * moveSpeed * Time.fixedDeltaTime);
            }

            if (moveup)
            {
                rb2d.AddForce(transform.up * moveSpeed * Time.fixedDeltaTime);
            }

            if (movedown)
            {
                rb2d.AddForce(transform.up * -moveSpeed * Time.fixedDeltaTime);
            }

            if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Z)) && canShoot)
            {
                bulletSpawner.Spawn();
                canShoot = false;
                StartCoroutine(shootDelay(delayTime));
            }
        }
       
    }

    IEnumerator shootDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        canShoot = true;
    }

    IEnumerator destroyShip()
    {
        Destroy(gameObject);
        gameObject.SetActive(false);
        yield return new WaitForSeconds(2);
        gameObject.SetActive(true);
    }

}
