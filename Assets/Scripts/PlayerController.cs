using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 80.2f;

    public float xRange = 24;

    private float fireRateTimer = 0;
    [SerializeField] private float fireRate = 1;

    public GameObject projectilePrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //If statements for checking if the player is trying to move out of the bounds
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        horizontalInput = Input.GetAxis("Horizontal");
        //Move the player
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        //IF the firerate is higher than 0, count it down.
        if (fireRateTimer > 0)
        {
            fireRateTimer -= Time.deltaTime;
        }
        //Set the firerate timer to 0
        else
        {
            fireRateTimer = 0;
        }

        //Debug.Log("Timer:" + fireRateTimer);

        //Key press check for shooting the projectile
        if (Input.GetKey(KeyCode.Space) && fireRateTimer <= 0)
        {
            //Call the shooting function
            Shoot();
        }

    }
    void Shoot()
    {
        //Shoot the projectile
        Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        //Call to reset the timer
        ResetTimer();
    }
    void ResetTimer()
    {
        //Reset the timer to the firerate.
        fireRateTimer = fireRate;
    }
}
