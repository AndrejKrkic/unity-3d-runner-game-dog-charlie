using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    private bool invulnerable = false, stop = false;

    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private GameObject endScreen, shield;
    [SerializeField]
    private float speed;

    private int score;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            stop = true;
            animator.SetBool("isRunning", false);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            stop = false;
            animator.SetBool("isRunning", true);
        }


        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                stop = true;
                animator.SetBool("isRunning", false);
            }

            if (touch.phase == TouchPhase.Ended)
            {
                stop = false;
                animator.SetBool("isRunning", true);
            }
        }

    }
    
    void FixedUpdate()
    {
        if (!stop)
        rb.MovePosition(transform.position + Vector3.forward * Time.deltaTime * speed);
    }

    public void AddScore()
    {
        score++;
        scoreText.text = score.ToString();
        speed += 0.5f;
    }

    public void BecomeInvulnerable()
    {
        stop = true;
        invulnerable = true;
        shield.SetActive(true);
        Invoke("BecomeVulnerable", 6f);
    }

    private void BecomeVulnerable()
    {
        invulnerable = false;
        shield.SetActive(false);
    }

    public void Dead()
    {
        if (invulnerable)
            return;

        if (score > PlayerPrefs.GetInt("Highscore"))
            PlayerPrefs.SetInt("Highscore", score);

        endScreen.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
