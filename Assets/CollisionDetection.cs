using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionDetection : MonoBehaviour
{
    public GameObject Rocket;
    private KeyboardHandling player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<KeyboardHandling>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collided game object has the specified tag
        if (collision.gameObject.CompareTag("GameObject"))
        {
            player.currentFuelLevel -= 10;
            Debug.Log(player.currentFuelLevel);
            Debug.Log("Collided with object with tag: " + "GameObject");
        }

        if (collision.gameObject.CompareTag("GameEnd"))
        {
            SceneManager.LoadScene("SampleScene");
            Debug.Log("Game Over");
        }

        if (collision.gameObject.CompareTag("DropZone"))
        {
            player.currentFuelLevel = player.fuelLevel;
            player.fuelLevel += 10;
            Debug.Log("Dropzone Hit");
        }
    }

}