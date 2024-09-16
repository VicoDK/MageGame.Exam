using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovment : MonoBehaviour
{
 
 // stores player pos
 public Transform player;
 // to store what the offset of the camera needs to be
  public Vector3 offset;
  

  void Update () 
  {
    if (player == null)
    {
      //do nothing
    }
    else
    {
      //here we change the pos og camera to look at the player
      transform.position = new Vector3 (player.position.x + offset.x, player.position.y + offset.y, offset.z); 
    }
  }
}