using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CrawlerBehaviour : MonoBehaviour {

    public Transform playerContainer;

    private NavMeshAgent navMeshAgent;
    void Start() {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update() {
        navMeshAgent.SetDestination(playerContainer.transform.position);
    }
}
