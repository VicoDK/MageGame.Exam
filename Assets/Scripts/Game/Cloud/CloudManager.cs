using UnityEngine;

public class CloudManager : MonoBehaviour
{
    public GameObject[] clouds;

    Transform playerTranform;
    private int cloudPicked;

    void Start()
    {
        playerTranform = GameObject.Find("PlayerBody").GetComponent<Transform>();
        SpawnClouds();
    }

    public void SpawnClouds()
    {
        cloudPicked = Random.Range(0, clouds.Length);
        Instantiate(clouds[cloudPicked], new Vector3(playerTranform.position.x - (clouds[cloudPicked].transform.localScale.x/2)-12f, 0, 0), Quaternion.identity, this.transform);
    }
}
