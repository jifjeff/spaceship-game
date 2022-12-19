using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//public class ShipStats : MonoBehaviour
//{
//    int hp;
    
//}
public class ShipController_c3 : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private bool moveleft;
    private bool moveright;
    private bool moveup;
    private bool movedown;    
    private bool canShoot;
    private bool canMove;
    private float delayTime = 0.2f;
    public float moveSpeed;
    public GameObject spaceship;
    public GameSettings_c3 gameSettings;
    public BulletSpawner_c3 bulletSpawner;
    public TMP_Text itemNotification;
    
    // Start is called before the first frame update
    void Start()
    {
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

            if (gameSettings.isDead)
            {
                delayTime = 0.2f;
                itemNotification.text = "";
                gameSettings.isDeadFalse();
            }
        }
       
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.tag == "Obstacle")
        {
            gameSettings.subtractLife();
            gameObject.SetActive(false);
            gameSettings.playerRespawn();
            canMove = true;
            canShoot = true;
            
        }

        else if(other.gameObject.tag == "Item")
        {
            itemNotification.text = $"{other.gameObject.name.ToString()} activated";
            StartCoroutine(itemDuration(10.0f));
            
        }
    }

    IEnumerator shootDelay(float delay)
    {
        bulletSpawner.Spawn();
        canShoot = false;
        yield return new WaitForSeconds(delay);
        canShoot = true;

    }

    IEnumerator itemDuration(float time) 
    {      
        delayTime = 0.1f;
        yield return new WaitForSeconds(time);
        delayTime = 0.2f;
        itemNotification.text = "";
    }
}