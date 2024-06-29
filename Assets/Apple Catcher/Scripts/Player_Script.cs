using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Player_Script : MonoBehaviour
{

    //---------------------------------------------------------------------------------
    // ATTRIBUTES
    //---------------------------------------------------------------------------------
    public TextMeshPro displayed_text;
    public float playing_time;
    public TextMeshPro displayed_timer;
    public SpawnerScript spawner_script;

    protected int score;
    protected float timer;
    protected AudioSource ref_audioSource;
    protected Animator ref_animator;

    //---------------------------------------------------------------------------------
    // METHODS
    //---------------------------------------------------------------------------------
    // Start is called before the first frame update
    void Start()
    {
        ref_audioSource = GetComponent<AudioSource>();
        ref_animator = GetComponent<Animator>();
        timer = playing_time;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0) {
            //Manage movement speed and animations
            float newSpeed = 0;

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                newSpeed = -10f;
                ref_animator.SetBool("isForwards", false);
            }
            else if ( Input.GetKey(KeyCode.RightArrow) )
            {
                newSpeed = 10f;
                ref_animator.SetBool("isForwards", true);
            }
            
            //Inform animator : Are we moving?
            ref_animator.SetBool("isMoving", newSpeed != 0);


            //Move with the speed found
            transform.Translate(newSpeed * Time.deltaTime, 0, 0);

            //We stop time if the spaceBar is pushed down
            if ( Input.GetKeyDown(KeyCode.Space) )
            {
                Time.timeScale = 0f;
            }
            else if ( Input.GetKeyUp(KeyCode.Space) )
            {
                Time.timeScale = 1.0f;
            }

            //Quit game
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }

            Timer();
        }
        else if (timer <= 0) {
            spawner_script.enabled = false;
            GameOver();
        }
        
    }

    //React to a collision (collision start)
    void OnCollisionEnter2D( Collision2D col )
    {
        score++;
        displayed_text.SetText("Score : " + score);

        ref_audioSource.Play();
    }

    void Timer() {
        timer -= Time.deltaTime;
        if (timer > 0) {
            int minute = (int)Math.Floor(timer/60);
            int second = (int)Math.Floor(timer - Math.Floor(timer/60)*60);
            if (second < 10) {
                displayed_timer.SetText(minute + ":0" + second);
            }
            else {
                displayed_timer.SetText(minute + ":" + second);
            }
        }
        else {
            timer = 0;
            displayed_timer.SetText("0:00");
            displayed_timer.color = Color.red;
        }
        
    }

    private void GameOver(){
        //SoundManagerBB.Instance.PlayGameOverSound();

        FindObjectOfType<GameOver>().ShowGameOver(score);
    
    }

}
