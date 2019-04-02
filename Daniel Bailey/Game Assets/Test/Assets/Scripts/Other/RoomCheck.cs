using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCheck : MonoBehaviour
{
    public List<GameObject> Enemy;
    public int NumberOfEnemies;
    private GameObject InactiveEnemy;
    public GameObject RoomDoor;

    // Start is called before the first frame update

    private void Update()
    {
        for (int i = 0; i < Enemy.Count; i++)
        {
            if (!Enemy[i].activeInHierarchy) //Finds inactive enemies
            {
                InactiveEnemy = Enemy[i];
                NumberOfEnemies--;
                Enemy.Remove(InactiveEnemy);
            }
        }

        if( NumberOfEnemies == 0)
        {
            Destroy(RoomDoor);
        }
    }
}

