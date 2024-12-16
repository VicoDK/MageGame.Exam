using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class DoorToNewScene : MonoBehaviour
{
    public SceneAsset Scene;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(Scene.name, LoadSceneMode.Single);
        }
    }
}
