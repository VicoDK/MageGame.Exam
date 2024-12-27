using UnityEngine;

public class PlayerInRoomDetechingSpawnEnemies : MonoBehaviour
{
    public GameObject player;
    public float spawnRate;

    int count;
    public GameObject spawnSquare;
    public float spawnRange;
    public float spawnLimit;
    public GameObject Enemy1;
    public GameObject Enemy2;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = other.gameObject;
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = null;
        }

    }

    public void Start()
    {
        InvokeRepeating("SpawnEnemies", 1f, spawnRate);
    }

    void SpawnEnemies()
    {
        if (player != null)
        {
            count = 0;
            float x;
            float y;
            while (spawnLimit> count)
            {
                x = spawnSquare.transform.position.x+Random.Range(-spawnSquare.transform.localScale.x/2,spawnSquare.transform.localScale.x/2);
                y = spawnSquare.transform.position.y+Random.Range(-spawnSquare.transform.localScale.y/2,spawnSquare.transform.localScale.y/2);
                if (spawnRange<Vector2.Distance(player.transform.position, new Vector2(x,y)))
                {
                    count++;
                    int Enemytype = Random.Range(1,3);
                    if (Enemytype == 1)
                    {
                        Instantiate(Enemy1, new Vector2(x,y), Quaternion.identity, this.transform);

                    }
                    else
                    {
                        Instantiate(Enemy2, new Vector2(x,y), Quaternion.identity, this.transform) ;
                    }
    
                }
            }
        }
    }
}
