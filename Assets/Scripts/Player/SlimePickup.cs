using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimePickup : MonoBehaviour
{
    //speed of coin when dropped
    public float speed;

    //direction and angle of coin when dropped
    private Vector2 fireDir;


	public void MobDrop() 
    {
        //random direction and angle
        fireDir.y = Random.Range(-1f, 1f);
        fireDir.x = Random.Range(-1f, 1f);
      
        //calculate the angel to fire the coin
        float angle = Mathf.Atan2(fireDir.y+2f, fireDir.x+ 2f) * Mathf.Rad2Deg; 
        //Change the dir of the coins
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        // get the rb and Add force to the coin
        GetComponent<Rigidbody2D>().AddForce(fireDir * speed, ForceMode2D.Impulse);

	}

}