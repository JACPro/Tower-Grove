using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankFire : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] Transform fireTransform;
    [SerializeField] Rigidbody shell;
    [SerializeField] float shotCooldown;
    [SerializeField] float shotSpeed;
    bool canFire;
    void Start()
    {
        canFire = true;
    }

    void Update()
    {

    }

    /*
    Return true if it was able to fire
    */
    public void fireShot() {
        if (canFire){
            Rigidbody shellInstance = Instantiate(shell, fireTransform.position, fireTransform.rotation) as Rigidbody;
            shellInstance.velocity = shotSpeed * fireTransform.forward;
            audioSource.Play();
            StartCoroutine(wait());
        }        
    }

    IEnumerator wait() {
        canFire = false;
        yield return new WaitForSeconds(shotCooldown);
        canFire = true;
    }
}
