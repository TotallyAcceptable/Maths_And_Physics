using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class KeyboardHandling : MonoBehaviour
{
    public float thrust;
    public float fuelLevel;
    public float fuelConsumption;
    public GameObject PlayerController;
    public float currentFuelLevel;
    


    public Rigidbody rb;
    public GameObject obstaclePrefab;
    public int spawnedObstacles = 0;
    public int maxSpawnRate = 5;
    bool spawn = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentFuelLevel = fuelLevel;

        
        Physics.gravity = new Vector3(0, -2.0f, 0);

    }

    private void FixedUpdate()
    {
        StartCoroutine(SpawmTime());
    }
    // Update is called once per frame
    void Update()
    {


        if (Input.GetKey("up") && currentFuelLevel > 0)
        {
            rb.AddRelativeForce(Vector3.up * thrust, ForceMode.Force);
            currentFuelLevel -= fuelConsumption * Time.deltaTime ;
            //Debug.Log(currentFuelLevel);

        }

        if (Input.GetKey("down") && currentFuelLevel > 0)
        {
          
        }

        if (Input.GetKey("left") && currentFuelLevel > 0)
        {
            rb.AddRelativeForce(Vector3.left * (thrust/2), ForceMode.Force);
            currentFuelLevel -= fuelConsumption * Time.deltaTime;
          
        }

        if (Input.GetKey("right") && currentFuelLevel > 0)
        {
            rb.AddRelativeForce(Vector3.right * (thrust/2), ForceMode.Force);
            currentFuelLevel -= fuelConsumption * Time.deltaTime;
         
        }

        if(currentFuelLevel <= 0) // prevents the fuel level from being less than 0 and restarts the scene
        {
            SceneManager.LoadScene("SampleScene");
        }

        currentFuelLevel = Mathf.Clamp(currentFuelLevel + 5f * Time.deltaTime, 0f, fuelLevel); // ensures the increase doesnt exceed the min max value
    }

    void SpawnObstacle()
    {
        Vector3 randomSpawnPosition = new Vector3(Random.Range(PlayerController.transform.position.x - 20, PlayerController.transform.position.x + 20), Random.Range(PlayerController.transform.position.y, PlayerController.transform.position.y + 125), 0);

        int i = Random.Range(0, 5);

        if ((Random.value > 0.9) && (Vector3.Distance(transform.position, transform.position) < 5))
        {
            Instantiate(obstaclePrefab, randomSpawnPosition, Quaternion.identity);
        }

    
    }
   
    IEnumerator SpawmTime()
    {
        while(spawn == true)
        {
            
            SpawnObstacle();
            //spawnedObstacles++;
            yield return new WaitForSeconds(4f);
        }
    }

}
