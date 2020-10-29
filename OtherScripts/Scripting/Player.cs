using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CapsuleCollider playerCollider;
    public float moveSpeed = 5f;
    // Initialize the variables for enemy script
    //private GameObject enemy;
    private Enemy enemyScript;

    private RaycastHit hit; // object that the raycast hits
    private Ray ray; // information about the ray we're casting out
    public float rayDistance = 4f; // distance of ray to shoot out

    // Start is called before the first frame update
    void Start()
    {
        playerCollider = this.GetComponent<CapsuleCollider>();
        playerCollider.height = 1f;
        playerCollider.center = new Vector3(0f, 0.5f, 0f);
        // Communicate with the enemy script from this player script
        // this line only works one enemy object as other enemies have different names
        //enemy = GameObject.Find("Battle_Dummy"); 
        //enemyScript = enemy.GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        // Put the parameters from input to the vector variable
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
        // Move the player with the vector variable 
        transform.Translate(movement * Time.deltaTime * moveSpeed);

        // testing with space press
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            enemyScript.enemyHealth--;
        }
        */

        // Ray shooting out
        // + new vector3(...) -> the ray shot from the middle of the player in y-axis
        ray = new Ray(transform.position + new Vector3(0f, playerCollider.center.y, 0f), transform.forward); // forward -> in the z direction
        Debug.DrawRay(ray.origin, ray.direction * rayDistance, Color.red);

        // getting information about the object the ray hits
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.distance < rayDistance)
            {
                if (hit.collider.gameObject.tag == "Enemy")
                {
                    print("Enemy ahead");
                }
            }
        }
    }

    // built-in method for on collision with other gameobject
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            enemyScript = collision.gameObject.GetComponent<Enemy>();
            enemyScript.enemyHealth--;
        }
    }
}
