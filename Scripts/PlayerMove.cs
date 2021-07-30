using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    //mix_X & max_X are the left & right boundaries of our game
    //We restric the player to move only between min_X & max_X
    private float min_X = -2.7f;
    private float max_X = 2.7f;

    /// <summary>
    /// Count time in seconds using "Coroutine" "CountTime()" & store it in "timer" variable of "int" datatype
    /// Change the time to "timer" in timer_text
    /// </summary>
    public Text timer_Text;

    //This variable is used to count the time
    private int timer;

    void Awake()
    {
        //Always use GetComponent in awake function only
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //Rsete the timescale from 0 to 1 while restarting the game
        Time.timeScale = 1f;
        StartCoroutine(CountTime());
    }

    // Update is called once per frame
    void Update()
    {
        Player_Movement();
        PlayerBounds();

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

    /// <summary>
    /// Not Allows The PLayer To MOve Outside The Boundaries(i.e min_X , max_X)
    /// </summary>
    void PlayerBounds()
    {
        //Creating A Variable called "temp" Of type "Vector3" for storing the player current position
        Vector3 temp = transform.position;

        if(temp.x > max_X)
        {
            temp.x = max_X;
        }else if(temp.x < min_X)
        {
            temp.x = min_X;
        }

        //Assigning the changed position to the orginal transform.position
        transform.position = temp;


    }
    /// <summary>
    /// Restarts The Game when the knife touches the player
    /// This function is called in "OnTriggerEnter2D"
    /// </summary>
    /// <returns></returns>
    IEnumerator RestartGame()
    {
        yield return new WaitForSecondsRealtime(2f);

        //Instead of this we can import unity engine & reduce the syntax
        UnityEngine.SceneManagement.SceneManager.LoadScene
            (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);

    }

    /// <summary>
    /// Calculates The Time In Seconds
    /// </summary>
    /// <returns></returns>
    IEnumerator CountTime()
    {
        yield return new WaitForSeconds(1f);
        timer++;
        timer_Text.text = "Timer: " + timer;

        StartCoroutine(CountTime());
    }

    /// <summary>
    /// Built In fucntion to detect collisons
    /// It is not required to call this funtion
    /// </summary>
    /// <param name="target"></param>
    private void OnTriggerEnter2D(Collider2D target)
    {
        //We detect the knife with the knife tag
        //Creating Knife Tag : Go to knifePrefab - Tags - Add Tag - Plus Symbol - Name it Knife - save 
        //Adding Tag : Click on tags - Select Knifes
        //If knife hit the player then our game stops
        if (target.tag == "Knife")
        {
            //timeScale will stop our game nothing can move in our game
            Time.timeScale = 0f;

            //calling restart method to restart the game
            StartCoroutine(RestartGame());
        }
    }

}
