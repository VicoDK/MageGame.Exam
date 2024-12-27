using UnityEngine;

public class BirdManager : MonoBehaviour
{
    public GameObject[] Birds;

    Transform playerTranform;
    private int BirdPicked;
    private float birdYValue;

    void Start()
    {
        playerTranform = GameObject.Find("PlayerBody").GetComponent<Transform>();
        SpawnClouds();
    }

    public void SpawnClouds()
    {
        BirdPicked = Random.Range(0, Birds.Length);
        birdYValue = Random.Range(6f, -6f);
        Instantiate(Birds[BirdPicked], new Vector3(playerTranform.position.x -12f, playerTranform.position.y + birdYValue, 0), Quaternion.identity, this.transform);
    }
}
