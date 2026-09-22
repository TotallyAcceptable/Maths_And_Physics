using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolder : MonoBehaviour
{
    // Start is called before the first frame update
    KeyboardHandling player;
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<KeyboardHandling>();
        player.rb.mass += 7;
        player.rb.drag += 0.05f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
