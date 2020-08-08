using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public static int xPos;
    public static int zPos;
    public static int enemyCount;

    // Start is called before the first frame update
    void Start()
    {

    }

    public static void enemyDrop(int waveNumber, ElementType element)
    {

        while (enemyCount < 10)
        {
            xPos = Random.Range(20, 480);
            zPos = Random.Range(20, 480);

            while (xPos < 400 && xPos > 100)
            {
                xPos = Random.Range(20, 480);
            }
            while (zPos < 400 && xPos > 100)
            {
                zPos = Random.Range(20, 480);
            }

            SummonCreature.SummonEnemy(new Vector3(xPos, Terrain.activeTerrain.SampleHeight(new Vector3(xPos, 0, zPos)), zPos), element);
            enemyCount += 1;
        }
    }

    public static ElementType findPrimaryEnemyElement()
    {
        ElementType element = ElementType.earth;
        int waveType = Random.Range(1,4);
        switch (waveType)
        {
            case 1:
                element = ElementType.earth;
                break;

            case 2:
                element = ElementType.fire;
                break;

            case 3:
                element = ElementType.water;
                break;

            case 4:
                element = ElementType.lightning;
                break;
        }
        return element;
    }

}

