using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class player : MonoBehaviour
{
    private bool IsStarted = false;
    public GameObject welcomeScreen;

    public float movementSpeed = 10f;
    float movement = 0f;
    Rigidbody2D rb;

    void CheckBounds() 
    { 
        if(rb.transform.position.x < -3.2f)
        {
            rb.transform.position = new Vector3(3.2f, rb.transform.position.y, this.transform.position.z);
        }
        if (rb.transform.position.x > 3.2f)
        {
            rb.transform.position = new Vector3(-3.2f, rb.transform.position.y, this.transform.position.z);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckBounds();
        if (Input.GetMouseButtonDown(0) && IsStarted == false)
        {
            IsStarted = true;
            welcomeScreen.gameObject.SetActive(false);

        }
        if (IsStarted == true)
        {
            if (Input.acceleration.x > 0)
            {
                rb.GetComponent<SpriteRenderer>().flipX = false;
            }
            else
            {
                rb.GetComponent<SpriteRenderer>().flipX = true;
            }
            movement = Input.acceleration.x * movementSpeed;
        }
    }
     void FixedUpdate()
    {

        Vector2 velocity = rb.velocity;
        velocity.x = movement;
        rb.velocity = velocity;
    }
        public GameObject retryScreen;
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.name == "border")
            {
                retryScreen.SetActive(true);
                Destroy(collision.gameObject);
            }
        }
}
