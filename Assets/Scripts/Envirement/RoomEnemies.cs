using UnityEngine;

public class RoomEnemies : MonoBehaviour
{
    public int enemyCount;
    public GameObject Gate;

    // Update is called once per frame
    void FixedUpdate()
    {
        enemyCount = this.transform.childCount;
        if (enemyCount <= 0)
        {
            Destroy(Gate);
        }
    }
}
