using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static GameManager thisManager = null;
    private Animation thisAnimation;
    public float velocity = 10;
    public Rigidbody rb;
    public GameObject obstacle;
    public float addScore;
    public Text score;

    void Start()
    {
        thisAnimation = GetComponent<Animation>();
        thisAnimation["Flap_Legacy"].speed = 3;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            thisAnimation.Play();
            rb.velocity = transform.up * velocity;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "lose")
        {
            Destroy(gameObject);
            SceneManager.LoadScene(1);
        }
        if(other.gameObject.name == "Collider")
        {
            addScore += 10;
            score.text = "SCORE : " + addScore;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "wall")
        {
            Destroy(gameObject);
            SceneManager.LoadScene(1);
        }
    }
}
