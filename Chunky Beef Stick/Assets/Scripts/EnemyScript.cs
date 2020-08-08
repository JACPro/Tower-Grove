using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class EnemyScript : CreatureScript
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.GetType() == typeof(BoxCollider)) {
            StartCoroutine(HitEnemy(col));
        }
    }
    

        IEnumerator HitEnemy(Collision col)
    {
        if (col.gameObject.tag == "Ally")
        {
            DealDamage(col.gameObject.GetComponent<Collider>());
        }
        else if (col.gameObject.tag == "Player")
        {
            Debug.Log("Tank hit player " + GameManager.playerHealth);
            GameManager.playerHealth -= this.damage;
        }
        else if (col.gameObject.tag == "Grove"){
            Debug.Log("Grove damage");
            GameManager.reduceHearts(1);
        }
        if (col.gameObject.GetComponent<CreatureScript>().health <= 0)
        {
            Destroy(col.gameObject);
            FindObjectOfType<GameManager>().DecrementEnemyCounter();
        }
        yield return new WaitForSeconds(1);
    }
}
