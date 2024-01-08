using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableQuiz : MonoBehaviour
{
    public GameObject Quiz;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collider belongs to the object you want to detect collisions with
        if (other.CompareTag("Player"))  // Replace "YourTag" with the actual tag of the object
        {
            Debug.Log("COLLIDED");
            // Enable the specified GameObject
            Quiz.SetActive(true);

            // Optionally, you can disable the trigger collider on the player
            // if you want to prevent repeated collisions until the trigger is exited.
            //GetComponent<Collider2D>().enabled = false;
        }
    }
}
