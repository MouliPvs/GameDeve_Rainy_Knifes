using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    /// <summary>
    /// Created A new variable called "anim" of datatype/property "Animator"
    /// Created A new bool varaible called "Walk" in -> Animator-Parameters-'+' Symbmol-bool
    /// We get the component i.e Animation(Idle_0) & store it in "anim"
    /// Creating Condition For Transition Between Walk & Idle -> Conditions - '+' - walk true/false
    /// Unchecking The Exit Time
    /// Reducing The transition Time to 0.1
    /// </summary>
    private Animator anim;

    /// <summary>
    /// Idle_0 sprite is attached to the player object
    /// Created A new variable called "sr" of datatype/property "SpriteRender"
    /// We get the component i.e Sprite(Idle_0) & store it in "sr"
    /// </summary>
    private SpriteRenderer sr;

    private float speed = 3f;

    void Awake()
    {
        //Always use GetComponent in awake function only
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Player_Movement();

    }

    void Player_Movement()
    {
        float h = Input.GetAxisRaw("Horizontal");
        Vector3 temp = transform.position;

        if (h > 0)
        {
            temp.x += speed * Time.deltaTime;
            sr.flipX = false;
            anim.SetBool("Walk", true);
        }
        else if (h < 0)
        {
            temp.x -= speed * Time.deltaTime;
            sr.flipX = true;
            anim.SetBool("Walk", true);
        }
        else if (h == 0)
        {
            anim.SetBool("Walk", false);
        }
        transform.position = temp;

    }

}
