using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public GameObject wave;

    public float moveSpeed = 3f;
    public float jumpForce = 500f;

    private Rigidbody2D rb;
    private SpriteRenderer sr;

    PlayerAnimation playerAnim;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        playerAnim = GetComponent<PlayerAnimation>();
    }
    
    void Update()
    {
        PlayerMove();
        PlayerJump();

        if (Input.GetKeyDown(KeyCode.K))
        {
            if (wave.activeInHierarchy)
            {
                return;
            }
            else
            {
                StartCoroutine(nameof(LightTheWay));
            }
        }
    }

    IEnumerator LightTheWay()
    {
        wave.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        wave.SetActive(false);
    }

    private void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (rb.velocity.y != 0f)
            {
                return;
            }

            rb.AddForce(Vector2.up* Time.deltaTime*jumpForce, ForceMode2D.Impulse);

            playerAnim.Jump(true);


        }
    }

    private void PlayerMove()
    {
        float h = Input.GetAxisRaw("Horizontal");

        if (h > 0) {
            Vector2 temp = transform.position;
            temp.x += moveSpeed * Time.deltaTime;
            transform.position = temp;

            sr.flipX = false;

            playerAnim.Walk(true);
        }
        else if (h < 0)
        {
            Vector2 temp = transform.position;
            temp.x -= moveSpeed * Time.deltaTime;
            transform.position = temp;

            sr.flipX = true;

            playerAnim.Walk(true);
        }
        else
        {
            playerAnim.Walk(false);
        }

        if (Mathf.Abs(rb.velocity.y) <= 0.01f)
        {
            playerAnim.Jump(false);
        }
    }
}
