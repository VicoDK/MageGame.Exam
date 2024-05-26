using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovment : MonoBehaviour
{
 //her laver vi 2 værdier som vi bruger senere 
 // her laver vi en værdier der trakker et objekt position og kaldt den player 
 public Transform player;
 // her laver  vi en vector 3 som skal holde styr på hvor megete offset der skal være mellem player og camera 
  public Vector3 offset;
  
  // updater hvert frame
  void Update () 
  {
    if (player == null)
    {
      //do nothing
    }
    else
    {
      // her ændre vi cameraet position til at være playeres + det offset vi lavet tidligere i unity
      transform.position = new Vector3 (player.position.x + offset.x, player.position.y + offset.y, offset.z); 
    }
  }
}