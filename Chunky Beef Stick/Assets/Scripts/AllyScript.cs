using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class AllyScript : CreatureScript
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
        HitEnemy(col);
    }

    IEnumerator HitEnemy(Collision col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            DealDamage(col.gameObject.GetComponent<Collider>());
        }
        if (col.gameObject.GetComponent<CreatureScript>().health <= 0)
        {
            Destroy(col.gameObject);
        }
        yield return new WaitForSeconds(1);
    }
}
