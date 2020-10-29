using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureChest : MonoBehaviour
{
    public bool interactable = false;
    private Animator anim;
    // Create variable to hold the prefab we want to instantiate
    public Rigidbody coinPrefab;
    // Create transform position for the object to instantiate
    public Transform spawner;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (interactable && Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("openChest", true);

            // Create instance of coin prefab and have it show and jump on the ground
            Rigidbody coinInstance;
            coinInstance = Instantiate(coinPrefab, spawner.position, spawner.rotation) as Rigidbody;
            coinInstance.AddForce(spawner.up * 100);
        }
    }

    // Built-in method for on trigger event such as enter(once), stay(loop) and exit(once)
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            interactable = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            interactable = false;
        }
    }
}
