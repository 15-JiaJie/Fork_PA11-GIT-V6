using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // Scores
    public Text ScoreText;
    private int Score;



    public float speed;

    private float MaxY = 3.9f;
    private float MinY = -3.8f;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(rb.IsSleeping())
        {
            rb.WakeUp();
        }

        float verticalInput = Input.GetAxis("Vertical");

        transform.position = transform.position + new Vector3(0 , verticalInput * speed * Time.deltaTime, 0);

        transform.position = new Vector3(-12.24f, Mathf.Clamp(transform.position.y, MinY, MaxY), 0);

        ScoreText.GetComponent<Text>().text = "Score: " + Score;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            
            SceneManager.LoadScene("GameOver");
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Scoring")
        {
            Score += 1;
        }
    }
}
