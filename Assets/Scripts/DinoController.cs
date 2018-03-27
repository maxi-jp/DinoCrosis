using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DinoController : MonoBehaviour
{

    [HideInInspector]
    public Animator animator;

    [HideInInspector]
    public NavMeshAgent agent;

    private void Reset()
    {
        animator = transform.Find("Model").GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }
    
    void Start ()
    {
        agent.SetDestination(new Vector3(10f, 0f, 10f));

    }
	
	void Update ()
    {
        animator.SetFloat("speed", agent.speed);
        if (!agent.pathPending)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                {
                    Debug.Log("Selecting new destination...");
                    agent.SetDestination(new Vector3(Random.Range(-10.0f, 10.0f), 0f, Random.Range(-10.0f, 10.0f)));

                }
            }
        }

    }

}
