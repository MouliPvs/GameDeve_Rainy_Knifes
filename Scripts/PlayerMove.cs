﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Animator anim;
    private SpriteRenderer sr;

    private float speed = 3f;

    void Awake()
    {
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
