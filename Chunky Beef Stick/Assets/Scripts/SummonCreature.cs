using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonCreature : MonoBehaviour
{
    
    static GameObject fireElemental;
    static GameObject earthElemental;
    static GameObject waterElemental;
    static GameObject lightningElemental;

    static GameObject fireEnemy;
    static GameObject earthEnemy;
    static GameObject waterEnemy;
    static GameObject lightningEnemy;

    static GameObject firePlant;
    static GameObject earthPlant;
    static GameObject waterPlant;
    static GameObject lightningPlant;

    static GameObject player;
    static GameObject enemyGoal;
    static Camera camera;

    public GameObject fireElementalAlly;
    public GameObject earthElementalAlly;
    public GameObject waterElementalAlly;
    public GameObject lightningElementalAlly;

    public GameObject fireTank;
    public GameObject earthTank;
    public GameObject waterTank;
    public GameObject lightningTank;

    public GameObject firePlants;
    public GameObject earthPlants;
    public GameObject waterPlants;
    public GameObject lightningPlants;

    public GameObject publicPlayer;
    public GameObject publicEnemyGoal;
    public Camera publicCamera;
    

    // Start is called before the first frame update
    void Start()
    {
        fireElemental = fireElementalAlly;
        earthElemental = earthElementalAlly;
        waterElemental = waterElementalAlly;
        lightningElemental = lightningElementalAlly;

        fireEnemy = fireTank;
        earthEnemy = earthTank;
        waterEnemy = waterTank;
        lightningEnemy = lightningTank;

        firePlant = firePlants;
        earthPlant = earthPlants;
        waterPlant = waterPlants;
        lightningPlant = lightningPlants;

        player = publicPlayer;
        enemyGoal = publicEnemyGoal;
        camera = publicCamera;
}

    // Update is called once per frame
    void Update()
    {
        
    }

    // summons enemies facing the goal
    // summon costs are the default values specified in GameManager
    public static bool SummonEnemy(Vector3 position, ElementType element)
    {
        Quaternion facing = player.transform.rotation;
        Vector3 direction = enemyGoal.transform.position - position;
        facing.SetLookRotation(direction, Vector3.up);

        switch (element)
        {
            case ElementType.fire:
                    Instantiate(fireEnemy, position, player.transform.rotation);
                    return true;

            case ElementType.earth:
                    Instantiate(earthEnemy, position, player.transform.rotation);
                    return true;

            case ElementType.water:
                    Instantiate(waterEnemy, position, player.transform.rotation);
                    return true;

            case ElementType.lightning:
                    Instantiate(lightningEnemy, position, player.transform.rotation);
                    return true;
        }
        return false;
    }

    public static void SummonAlly(ElementType element)
    {
        camera = GameObject.FindObjectOfType<SummonCreature>().publicCamera;
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            Vector3 dest = ray.GetPoint(hit.distance);
        }

        if (GameManager.enemiesRemaining == 0 && hit.collider.gameObject.tag == "Plot")
        {
            switch (element)
            {
                case ElementType.fire:
                    Destroy(hit.collider.gameObject);
                    Instantiate(firePlant, new Vector3(hit.transform.position.x, (hit.transform.position.y-(hit.collider.bounds.size.y/2)) + (firePlant.GetComponent<Collider>().bounds.size.y / 2) + 0.01f, hit.transform.position.z), hit.transform.rotation);
                    break;
                case ElementType.earth:
                    Destroy(hit.collider.gameObject);
                    Instantiate(earthPlant, new Vector3 (hit.transform.position.x, (hit.transform.position.y - (hit.collider.bounds.size.y / 2)) + (earthPlant.GetComponent<Collider>().bounds.size.y / 2) + 0.01f, hit.transform.position.z) , hit.transform.rotation);
                    break;
                case ElementType.water:
                    Destroy(hit.collider.gameObject);
                    Instantiate(waterPlant, new Vector3(hit.transform.position.x, (hit.transform.position.y - (hit.collider.bounds.size.y / 2)) + (waterPlant.GetComponent<Collider>().bounds.size.y / 2) + 0.01f, hit.transform.position.z), hit.transform.rotation);
                    break;
                case ElementType.lightning:
                    Destroy(hit.collider.gameObject);
                    Instantiate(lightningPlant, new Vector3(hit.transform.position.x, (hit.transform.position.y - (hit.collider.bounds.size.y / 2)) + (lightningPlant.GetComponent<Collider>().bounds.size.y / 2) + 0.01f, hit.transform.position.z), hit.transform.rotation);
                    break;
            }
            
        }

        else if (hit.transform.position != null && hit.collider.gameObject.tag == "Ground" && GameManager.CheckSummonable(element))
        {
            Vector3 dest = ray.GetPoint(hit.distance);
            dest = new Vector3(dest.x, (dest.y + (earthElemental.GetComponent<Collider>().bounds.size.y)/2) + 0.01f, dest.z);
            switch (element)
            {               
                case ElementType.fire:
                    Instantiate(fireElemental, dest, player.transform.rotation);
                    Debug.Log("fire");
                    GameManager.TakeResource(element);
                    break;
                case ElementType.earth:
                    Instantiate(earthElemental, dest, player.transform.rotation);
                    Debug.Log("earth");
                    GameManager.TakeResource(element);
                    break;
                case ElementType.water:
                    Instantiate(waterElemental, dest, player.transform.rotation);
                    Debug.Log("water");
                    GameManager.TakeResource(element);
                    break;
                case ElementType.lightning:
                    Instantiate(lightningElemental, dest, player.transform.rotation);
                    Debug.Log("lightning");
                    GameManager.TakeResource(element);
                    break;
            }
        }
    }

}
