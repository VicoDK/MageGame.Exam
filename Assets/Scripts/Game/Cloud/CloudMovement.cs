using UnityEngine;
using UnityEngine.SocialPlatforms;

public class CloudMovement : MonoBehaviour
{
    public float maxSpeed;
    public float minSpeed;
    private float speed;

    Rigidbody2D rb;

    Transform playerTranform;
    private float cloudSize;
    CloudManager cloudManager;

    void Start()
    {
        cloudManager = GameObject.Find("CloudManager").GetComponent<CloudManager>();
        cloudSize = GetComponent<Transform>().localScale.x/2;
        speed = Random.Range(minSpeed, maxSpeed);
        rb = GetComponent<Rigidbody2D>();
        playerTranform = GameObject.Find("PlayerBody").GetComponent<Transform>();
    }

    void FixedUpdate()
    {
       
        rb.linearVelocity = new Vector2(speed,0)*Time.deltaTime;

        if (this.transform.position.x >= playerTranform.position.x + cloudSize+12)
        {
            cloudManager.SpawnClouds();
            Destroy(gameObject);

        }


    }
}
