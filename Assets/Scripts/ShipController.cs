using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//public class ShipStats : MonoBehaviour
//{
//    int hp;
    
//}
public class ShipController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private bool moveleft;
    private bool moveright;
    private bool moveup;
    private bool movedown;    
    private bool canShoot;
    private bool canMove;
    private string clone = "(Clone)";
    private float delayTime;
    public float moveSpeed;
    public GameObject spaceship;
    public GameSettings gameSettings;
    public BulletSpawner bulletSpawner;
    
    

    // Start is called before the first frame update
    void Start()
    {
        delayTime = 0.2f;
        moveSpeed = 8.0f;
        Time.timeScale = 1;
        canShoot = true;
        canMove = true;
        rb2d = GetComponent<Rigidbody2D>();

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
                StartCoroutine(shootDelay(delayTime));
            }
        }
       
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.tag == "Obstacle")
        {

            gameSettings.isPausedTrue();
            gameSettings.subtractLife();
            gameObject.SetActive(false);
            gameSettings.playerRespawn();
            canMove = true;
            canShoot = true;
            
        }
        //else if(other.gameObject.name == "FireRateBoost" +clone)
        //{
        //    Debug.Log("Boost Started");
        //    float startingDelayTime = delayTime;
        //    delayTime = 0.1f;
        //    StartCoroutine(wait(10.0f));
        //    delayTime = startingDelayTime;
        //}
    }

    IEnumerator shootDelay(float delay)
    {
        bulletSpawner.Spawn();
        canShoot = false;
        yield return new WaitForSeconds(delay);
        canShoot = true;
    }

    IEnumerator wait(float time) //duration courotine
    {
        yield return new WaitForSeconds(time);
    }
}