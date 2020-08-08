using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AllyMovement : MonoBehaviour
{
    Transform spawnPos;
    Transform target;    
    void Start()
    {
        spawnPos = transform;
        target = spawnPos;
    }

    void Update()
    {        
        GetComponent<NavMeshAgent>().destination = target.position;
    }

    private void OnTriggerStay(Collider other) {
        //if Collide with enemy
        if (other.gameObject.tag == "Enemy") {
            target = other.gameObject.transform;
        }
    }

    private void OnTriggerExit(Collider other) {
        target = spawnPos;
    }    
}
