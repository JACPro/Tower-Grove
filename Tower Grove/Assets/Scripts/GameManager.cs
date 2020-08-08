using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static int waterResource;
    static int fireResource;
    static int earthResource;
    static int lightningResource;
    static int hearts;
    static int resourceIncrement = 10;
    static Difficulty difficulty;
    public static int playerHealth;

    // to change this per plant, make the plant class have a public value which is passed to GiveResource to increment by
    public static int resourceInc = 10;
    public static Difficulty difficultLevel = Difficulty.medium;
    public static int playerHP = 50;

    public static int baseEnemyCount;
    public static int countdownInterval = 30;
    public static int enemiesRemaining;
    static int wave;

    // Start is called before the first frame update
    void Start()
    {
        RestartGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SummonCreature.SummonAlly(ElementType.earth);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SummonCreature.SummonAlly(ElementType.fire);
            Debug.Log("fire");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SummonCreature.SummonAlly(ElementType.water);
            Debug.Log("water");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SummonCreature.SummonAlly(ElementType.lightning);
        }

    }

    // resets all resources, wave count, and hearts.
    void RestartGame()
    {
        resourceIncrement = resourceInc;
        difficulty = difficultLevel;
        playerHealth = playerHP;
        waterResource = 0;
        fireResource = 0;
        earthResource = 0;
        lightningResource = 0;
        wave = 0;
        playerHealth = 50;
        switch (difficulty)
        {
            case Difficulty.easy:
                hearts = 5;
                break;
            case Difficulty.medium:
                hearts = 3;
                break;
            case Difficulty.hard:
                hearts = 1;
                break;
        }
        NextWave();
    }

    // Gives amt of resource to the player
    public static void GiveResource(ElementType foo)
    {
        switch (foo)
        {
            case ElementType.earth:
                GameManager.earthResource += GameManager.resourceIncrement;
                Debug.Log("EARTH resource given");
                break;
            case ElementType.fire:
                GameManager.fireResource += GameManager.resourceIncrement;
                Debug.Log("FIRE resource given");
                break;
            case ElementType.water:
                GameManager.waterResource += GameManager.resourceIncrement;
                Debug.Log("WATER resource given");
                break;
            case ElementType.lightning:
                GameManager.lightningResource += GameManager.resourceIncrement;
                Debug.Log("LIGHTNING resource given");
                break;

        }
    }

    public static void TakeResource(ElementType element, int deduction = 10)
    {
        switch (element)
        {
            case ElementType.earth:
                earthResource -= deduction;
                break;
            case ElementType.fire:
                fireResource -= deduction;
                break;
            case ElementType.lightning:
                lightningResource -= deduction;
                break;
            case ElementType.water:
                waterResource -= deduction;
                break;
        }
    }

    // checks if u can summon a golem as its cost is lower than ur current resource amount
    public static bool CheckSummonable(ElementType element, int cost = 10)
    {
        switch (element)
        {
            case ElementType.fire:
                if (cost <= fireResource) return true;
                else return false;
            case ElementType.water:
                if (cost <= waterResource) return true;
                else return false;
            case ElementType.earth:
                if (cost <= earthResource) return true;
                else return false;
            case ElementType.lightning:
                if (cost <= lightningResource) return true;
                else return false;
        }
        return false;
    }

    public static void reduceHearts(int loss){
        hearts -= loss;
    }

    [SerializeField]
    public Transform building_pop_1, building_pop_2, building_pop_3, building_pop_4;
    [SerializeField]
    public Transform building_spawn_1, building_spawn_2, building_spawn_3, building_spawn_4;
    public void DecrementEnemyCounter()
    {
        enemiesRemaining -= 1;
        if(enemiesRemaining == 0)
        {
            GameObject.FindObjectOfType<GameManager>().NextWave();

            switch (wave)
            {
                case 1:
                    gameObject.GetComponent<building_pop>().repair(building_spawn_1, building_pop_1);
                    break;
                case 2:
                    gameObject.GetComponent<building_pop>().repair(building_spawn_2, building_pop_2);
                    break;
                case 3:
                    gameObject.GetComponent<building_pop>().repair(building_spawn_3, building_pop_3);
                    break;
                case 4:
                    gameObject.GetComponent<building_pop>().repair(building_spawn_4, building_pop_4);
                    break;

            }
        }
    }

    void NextWave()
    {
        StartCoroutine(GameManager.Countdown());
    }

    static IEnumerator Countdown()
    {
        wave++;
        int primary = (baseEnemyCount * wave / (Random.Range(1,4)));
        int secondary = (baseEnemyCount * wave / 4);
        enemiesRemaining = primary + (3 * secondary);
        
        yield return new WaitForSeconds(countdownInterval);

        switch (SpawnScript.findPrimaryEnemyElement())
        {
            case ElementType.earth:
                SpawnScript.enemyDrop(primary, ElementType.earth);
                SpawnScript.enemyDrop(secondary, ElementType.fire);
                SpawnScript.enemyDrop(secondary, ElementType.lightning);
                SpawnScript.enemyDrop(secondary, ElementType.water);
                break;

            case ElementType.fire:
                SpawnScript.enemyDrop(secondary, ElementType.earth);
                SpawnScript.enemyDrop(primary, ElementType.fire);
                SpawnScript.enemyDrop(secondary, ElementType.lightning);
                SpawnScript.enemyDrop(secondary, ElementType.water);
                break;

            case ElementType.water:
                SpawnScript.enemyDrop(secondary, ElementType.earth);
                SpawnScript.enemyDrop(secondary, ElementType.fire);
                SpawnScript.enemyDrop(secondary, ElementType.lightning);
                SpawnScript.enemyDrop(primary, ElementType.water);
                break;

            case ElementType.lightning:
                SpawnScript.enemyDrop(secondary, ElementType.earth);
                SpawnScript.enemyDrop(secondary, ElementType.fire);
                SpawnScript.enemyDrop(primary, ElementType.lightning);
                SpawnScript.enemyDrop(secondary, ElementType.water);
                break;
        }
    }
}
