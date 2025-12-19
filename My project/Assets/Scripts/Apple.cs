using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Apple : MonoBehaviour
{

    private SpriteRenderer sr;
    private CircleCollider2D cc;
    public int Score;

    public GameObject collected;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        sr = GetComponent<SpriteRenderer>();
        cc = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {   
            sr.enabled = false;
            cc.enabled = false;
            collected.SetActive(true);


            GameController.instance.totalScore += Score;
            Destroy(this.gameObject, 0.25f);
        }
    }
}
  