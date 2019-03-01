using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Hmovement : MonoBehaviour
{

    SpriteRenderer sprite;
    private Rigidbody2D rb;
    // public Text countText;
    // public Text popCoinText;
    // public ParticleSystem particle;
    float y;
    public Animator anim;
    bool isRunning;
    bool scene4 = false;
 
    bool grounded=true;
    static int maxjumps = 1;
    int jumps;
    float jumpforce = 3F;

    GameObject CheckPointObject;
    public bool CheckPointTrigger = false;
    public float FallMultiplier = 2.51f;

    //coins Property
    public ParticleSystem particle;
    public static int coinCount;
    
    //Score-Pop-Up Property

    // Use this for initialization
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        coinCount = 0;

        if (SceneManager.GetActiveScene().name == "Level4")
        {
            scene4 = true;
            Physics2D.gravity = new Vector2(0, -1.62f);
        }

        // CheckPointObject = GameObject.FindWithTag("CheckPoint");
        // //player position - chcekpoint position<0 checcTrigger false
        // if (CheckPointObject)
        // {
        //     if ((transform.position.x - CheckPointObject.transform.position.x) < 0)
        //     {
        //         CheckPointTrigger = false;
        //     }
        //     else if ((transform.position.x - CheckPointObject.transform.position.x) >= 0)
        //     {
        //         CheckPointTrigger = true;
        //     }
        // }

        //player position - chcekpoint position>0 checTrigger True

        //Score-Pop up initialization
    }

    // Update is called once per frame
    void Update()
    {
        if (scene4 == true)
        {
            anim.SetInteger("HeroState", 1);
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(0.01f, 0, 0);
                sprite.flipX = false;
                anim.SetInteger("HeroState", 0);

            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(-0.01f, 0, 0);
                sprite.flipX = true;
                anim.SetInteger("HeroState", 0);

            }
        }
        else
        {
            anim.SetInteger("HeroState", 1);
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(0.15f, 0, 0);
                sprite.flipX = false;
                anim.SetInteger("HeroState", 0);

            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(-0.15f, 0, 0);
                sprite.flipX = true;
                anim.SetInteger("HeroState", 0);

            }
        }
        // if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        // {
        //     Jump();
        // }

        transform.rotation = new Quaternion(0, 0, 0, 0);

        //Falling Part
        // if(rb.velocity.y<0){
        //         rb.velocity += Vector2.up * Physics2D.gravity.y * (FallMultiplier-1) * Time.deltaTime;
        // }
    }

    // void Jump()
    // {
    //     if (jumps > 0)
    //     {
    //         print("Enter");
    //         rb.AddForce(new Vector2(0, jumpforce), ForceMode2D.Impulse);
    //         grounded = false;
    //         jumps = jumps - 1;
    //     }
    //     if (jumps == 0) { return; }
    // }



    // void OnCollisionStay2D(Collision2D other)
    // {
    //     // if (other.gameObject.tag == "Ground")
    //     // {
    //         jumps = maxjumps;
    //         grounded = true;
    //         //  movespeed = 2.0F;
    //     // }

    //     if (other.gameObject.tag != "enemy" || other.gameObject.tag != "senemy")
    //     {
    //         if (scene4 == true)
    //         {
    //             if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow))
    //             {
    //                 rb.velocity = new Vector2(rb.velocity.x, 0f);
    //                 rb.AddForce(Vector2.up * 130);
    //                 anim.SetInteger("HeroState", 1);
    //             }
    //         }

    //         else
    //         {
    //             if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow))
    //             {
    //                 rb.velocity = new Vector2(rb.velocity.x, 0f);
    //                 rb.AddForce(Vector2.up * 350);
    //                 anim.SetInteger("HeroState", 1);
    //             }
    //         }

    //     }

    // }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coins"))
        {
            other.gameObject.SetActive(false);
            Instantiate(particle, other.gameObject.transform.GetChild(0).gameObject.transform.position, Quaternion.identity);
            coinCount = coinCount + 1;
          //  countText.text = count.ToString();
        }

        // if (other.gameObject.CompareTag("CheckPoint"))
        // {
        //     CheckPointTrigger = true;
        // }
    }
}


