using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    Transform goal;
    Transform target = null;    
    //Check if the enemy is near the grove (for slowing when close)
    bool inCentre = false;
    //Check if enemy is in the area which the allies can traverse
    bool inZone;
    float speed;
    void Start()
    {
        speed = GetComponent<NavMeshAgent>().speed;
        goal = GameObject.FindGameObjectWithTag("Grove").transform;
    }

    void Update()    
    {
        if (target != null && !inCentre) {
            //rotate towards the player you're looking at
            Quaternion lookTowards = Quaternion.LookRotation(target.position - transform.position);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, lookTowards, 100f * Time.deltaTime);
            GetComponent<NavMeshAgent>().destination = target.position;        
        } else {
            GetComponent<NavMeshAgent>().destination = goal.position;    
        }

        if (Vector3.Distance(transform.position, GetComponent<NavMeshAgent>().destination) < 6f) {
            GetComponent<TankFire>().fireShot();
        }

        if (Input.GetKeyDown(KeyCode.L)) {
            //Debug.Log("MyPos: " + transform.position + "\nDestination: " + GetComponent<NavMeshAgent>().destination);
        }        
    }    
    
    private void OnTriggerStay(Collider other) {
        if (other.gameObject.tag == "Ally" || other.gameObject.tag == "Player") {
            if (target == null) {
                target = other.gameObject.transform;    
            }
        //Check if enemies are in range of allies
        } else if (other.gameObject.tag == "AllyZone") {
            inZone = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        target = null;
    }

    private void OnTriggerEnter(Collider other) {
        //Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "SlowGrove") {
            GetComponent<NavMeshAgent>().speed = speed / 2;
            inCentre = true;
        }    
    }
}
