using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class hero : MonoBehaviour
{

    public float sense;
    public int lives = 3;
    int seconds = 0;
    public TextMeshProUGUI livesText, gameOver, score, time, startAcces;

    public static bool startAccesBool = false;
    public GameObject button;

    void Start()
    {
        button.SetActive(false);
        livesText.text = lives.ToString();
        startAcces.text = "Press Any Key To Start..";
        Time.timeScale = 0;
    }

    void Update()
    {
        if (startAccesBool == false)
        {
            if (Input.anyKeyDown)
            {
                Time.timeScale = 1;
                startAcces.text = "";
                startAccesBool = true;
                StartCoroutine(calculateScore());
            }
        }
        if (startAccesBool == true)
        {
            float moving = Input.GetAxis("Horizontal") * sense;
            transform.Translate(moving * Time.deltaTime, 0f, 0f);

            float x = Mathf.Clamp(transform.position.x, -8.205f, 8.205f);
            transform.position = new Vector2(x, transform.position.y);
        }

    }
    void OnCollisionEnter2D(Collision2D fail)
    {
        lives--;
        livesText.text = lives.ToString();
        if (lives == 0)
        {
            button.SetActive(true);
            Time.timeScale = 0;
            gameOver.text = "GAME OVER";
            score.text = "Your Score: " + seconds.ToString() + " sec";
        }
    }
    IEnumerator calculateScore()
    {

        while (gameOver.text != "GAME OVER")
        {
            yield return new WaitForSecondsRealtime(1);
            seconds++;
            time.text = "Time: " + seconds + " sec";
            if (seconds == 10)
            {
                knife.dusmeHizi += 0.5f;
            }
            if (seconds == 15)
            {
                knife.dusmeHizi += 0.5f;
            }
            if (seconds == 20)
            {
                knife.dusmeHizi += 0.5f;
            }
        }


    }
    public void playAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        startAccesBool = false;
        Time.timeScale = 1;
        seconds = 0;
        lives = 3;
    }



}
