using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBound = 30;
    private float lowerBound = -10;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        //Find the game manager with it's tag
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //If the object reaches out of the bounds, from the top, destroy it
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < lowerBound)
        {
            //Debug.Log("Game Over!");
            Destroy(gameObject);

            //Calls the GameManager to end the game and show the ending screen
            gameManager.TheGameOver(true);
        }
    }
}