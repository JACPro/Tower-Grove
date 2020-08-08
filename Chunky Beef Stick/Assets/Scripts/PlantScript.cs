using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantScript : MonoBehaviour
{
    public int resourceDelay = 10;
    public ElementType element = ElementType.water;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GiveResource());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // gives player resource of plant type
    IEnumerator GiveResource()
    {
        while (true)
        {
            Debug.Log("Charging resource...");
            yield return new WaitForSeconds(resourceDelay);
            switch (element)
            {
                case ElementType.water:
                    GameManager.GiveResource(ElementType.water);
                    break;
                case ElementType.fire:
                    GameManager.GiveResource(ElementType.fire);
                    break;
                case ElementType.earth:
                    GameManager.GiveResource(ElementType.earth);
                    break;
                case ElementType.lightning:
                    GameManager.GiveResource(ElementType.lightning);
                    break;
            }
        }
    }
}
