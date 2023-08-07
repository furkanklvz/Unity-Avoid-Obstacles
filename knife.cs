using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class knife : MonoBehaviour
{

    public static float dusmeHizi = 5f;


    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (hero.startAccesBool == true)
        {
            transform.Translate(0f, -1.5f * dusmeHizi * Time.deltaTime, 0f);
        }

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "hero")
        {
            transform.position = new Vector2(Random.Range(-8f, 8f), Random.Range(5.80f, 9f));
        }
        else if (collision.gameObject.tag == "controlBar")
        {
            transform.position = new Vector2(Random.Range(-8f, 8f), Random.Range(5.80f, 9f));
        }
    }
}
