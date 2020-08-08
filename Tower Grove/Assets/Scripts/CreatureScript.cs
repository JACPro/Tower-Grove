using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureScript : MonoBehaviour
{
    public float health = 50;
    public int damage = 10;
    public ElementType element = ElementType.earth;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // if creature is weak to element, take that damage * 1.5
    // if creature is strong to element, take that damage * 0.75
    // else take damage * 1
    public void DealDamage(Collider enemy)
    {
        Debug.Log("Checking Element...");
        // if(enemy element was)
        switch (enemy.gameObject.GetComponent<CreatureScript>().element)
        {
            case ElementType.earth: // if the enemy is this element
                if (element == ElementType.lightning) // if this creature is lightning
                {
                    Debug.Log("enemy earth, self lightning");
                    enemy.gameObject.GetComponent<CreatureScript>().health -= this.damage * 1.5f;
                }
                else if (element == ElementType.fire) // if this creature is 
                {
                    Debug.Log("enemy earth, self fire");
                    enemy.gameObject.GetComponent<CreatureScript>().health -= this.damage * 0.75f;
                }

                else // no strong or weak enemy element
                {
                    Debug.Log("enemy earth");
                    enemy.gameObject.GetComponent<CreatureScript>().health -= this.damage; // take unaltered damage
                }
                break;

            case ElementType.fire:
                if (element == ElementType.earth) // take increased damage as this is weak to enemy element
                {
                    Debug.Log("enemy fire, self earth");
                    enemy.gameObject.GetComponent<CreatureScript>().health -= this.damage * 1.5f;
                }
                else if (element == ElementType.water) // take decreased damage as this is strong against enemy element
                {
                    Debug.Log("enemy water, self water");
                    enemy.gameObject.GetComponent<CreatureScript>().health -= this.damage * 0.75f;
                }
                else // no strong or weak enemy element
                {
                    Debug.Log("enemy fire");
                    enemy.gameObject.GetComponent<CreatureScript>().health -= this.damage; // take unaltered damage
                }
                break;
            case ElementType.lightning:
                if (element == ElementType.water) // take increased damage as this is weak to enemy element
                {
                    Debug.Log("enemy light, self water");
                    enemy.gameObject.GetComponent<CreatureScript>().health -= this.damage * 1.5f;
                }
                else if (element == ElementType.earth) // take decreased damage as this is strong against enemy element
                {
                    Debug.Log("enemy light, self earth");
                    enemy.gameObject.GetComponent<CreatureScript>().health -= this.damage * 0.75f;
                }
                else // no strong or weak enemy element
                {
                    Debug.Log("enemy light");
                    enemy.gameObject.GetComponent<CreatureScript>().health -= this.damage; // take unaltered damage
                }
                break;

            case ElementType.water:
                if (element == ElementType.fire) // take increased damage as this is weak to enemy element
                {
                    Debug.Log("enemy water, self fire");
                    enemy.gameObject.GetComponent<CreatureScript>().health -= this.damage * 1.5f;
                }
                else if (element == ElementType.lightning) // take decreased damage as this is strong against enemy element
                {
                    Debug.Log("enemy, self light");
                    enemy.gameObject.GetComponent<CreatureScript>().health -= this.damage * 0.75f;
                }
                else // no strong or weak enemy element
                {
                    Debug.Log("enemy water");
                    enemy.gameObject.GetComponent<CreatureScript>().health -= this.damage; // take unaltered damage
                }
                break;
        }
    }
}
