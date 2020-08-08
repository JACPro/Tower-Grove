using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class building_pop : MonoBehaviour
{
    [SerializeField]
    public Transform building_pop_1, building_pop_2, building_pop_3, building_pop_4;
    [SerializeField]
    public Transform building_spawn_1, building_spawn_2, building_spawn_3, building_spawn_4;
    bool is_changing;
    Transform currentRepair;
    Transform currentPop;

    public void repair(Transform building_to_spawn, Transform building_to_pop)
    {
        currentRepair = building_to_spawn;
        currentPop = building_to_pop;
        // Distance moved equals elapsed time times speed..
        float distCovered = (Time.time - startTime) * speed;

        // Fraction of journey completed equals current distance divided by total distance.
        float fractionOfJourney = distCovered / 1;

        building_to_spawn.localScale = Vector3.Lerp( new Vector3(1, 0, 1), new Vector3(1, 1, 1), fractionOfJourney);
        building_to_pop.localScale = Vector3.Lerp(new Vector3(1, 1, 1), new Vector3(1, 0, 1), fractionOfJourney);

        
    }

    // Movement speed in units per second.
    [SerializeField]
    public float speed = 1.0F;

    // Time when the movement started.
    private float startTime;

    // Start is called before the first frame update
    void Start()
    {

    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            is_changing = true;
            // Keep a note of the time the movement started.
            startTime = Time.time;
        }
        if (is_changing)
        {
            repair(currentRepair, currentPop);

            if (currentRepair.localScale == new Vector3(1, 1, 1))
            {
                is_changing = false;
            }
        }
    }
}
