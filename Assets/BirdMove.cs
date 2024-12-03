using UnityEngine;

public class BirdMove : MonoBehaviour
{
    public float maxSpeed;
    public float minSpeed;
    private float speed;

    Rigidbody2D rb;

    Transform playerTranform;
    private float birdSize;
    BirdManager birdManager;

    void Start()
    {
        birdManager = GameObject.Find("BirdManager").GetComponent<BirdManager>();
        birdSize = GetComponent<Transform>().localScale.x/2;
        speed = Random.Range(minSpeed, maxSpeed);
        rb = GetComponent<Rigidbody2D>();
        playerTranform = GameObject.Find("PlayerBody").GetComponent<Transform>();
    }

    void FixedUpdate()
    {
       
        rb.linearVelocity = new Vector2(speed,0)*Time.deltaTime;

        if (this.transform.position.x >= playerTranform.position.x + birdSize+12)
        {
            birdManager.SpawnClouds();
            Destroy(gameObject);

        }


    }
}
