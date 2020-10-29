using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactables : MonoBehaviour
{
    public bool interactable = false;

    public Material[] material;
    private Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0]; // 0->normal material, 1->outline material

    }

    public virtual void Interact() // virtual allows it to be overidden by another script
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (interactable && Input.GetKeyDown("space")) //button2->right on the right)
        {
            Interact();
        }

        if (interactable)
        {
            rend.sharedMaterial = material[1];
        }
        else
        {
            rend.sharedMaterial = material[0];
        }
    }

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
