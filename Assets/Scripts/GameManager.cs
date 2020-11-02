using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]private GameObject gameOverScreen;

    //Boolean variable for game's status if it's over or not.
    bool gameOver = false;

    public bool TheGameOver(bool status)
    {
        return (gameOver = status);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //If the game is over, activate the ending screen.
        if (gameOver == true)
        {
            gameOverScreen.SetActive(true);
        }
    }
}
