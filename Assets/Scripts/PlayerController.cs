using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    private Animator anim;
    private NavMeshAgent agent;
    // Awake is called when the script instance is being loaded
    void Awake()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        anim.SetFloat("Speed", agent.velocity.magnitude);
    }
}
