using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 80.2f;

    public float xRange = 24;

    private float fireRateTimer = 1;
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

        if (fireRateTimer >=0)
        {
            fireRateTimer -= Time.deltaTime;
        }

        Debug.Log(fireRateTimer);

        //Key press check for shooting the projectile
        if (Input.GetKey(KeyCode.Space) && fireRateTimer <= 0)
        {
            Shoot();
        }

    }

    void Shoot()
    {
        //Shoot the projectile
        Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        ResetTimer();
    }

    void ResetTimer()
    {
        fireRateTimer = fireRate;
    }
}
