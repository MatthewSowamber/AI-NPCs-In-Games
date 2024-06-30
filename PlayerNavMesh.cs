using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerNavMesh : MonoBehaviour

// An Array to allow for multiple goals to be set (Adding [])
{
    [SerializeField] private Transform[] movePositionTransform;
    int targetIndex;

    float destinationDistance;

    private NavMeshAgent navMeshAgent;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        targetIndex = 0;
        movePositionTransform[0] = GameObject.Find("End").transform; 
    }

    private void Update()
    {
        //Setting the destination

        navMeshAgent.destination = movePositionTransform[targetIndex].position;

        destinationDistance = Vector3.Distance(transform.position, navMeshAgent.destination);

        if (destinationDistance <= 1f)
        {
            targetIndex++;

            if (targetIndex == movePositionTransform.Length)
            {
                targetIndex = 0;
            }

        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Goal")
        {
            Debug.Log("Goal");
            Score.instance.AddScore();
            Destroy(this.gameObject);
        }
    }
}
