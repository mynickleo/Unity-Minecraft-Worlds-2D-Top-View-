using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMobsAttack : MonoBehaviour
{
    public GameObject[] MobsAttack;

    private int ActionSpawn = 0;
    public void Start()
    {
        StartCoroutine("NightSpawn");
    }

    IEnumerator NightSpawn()

    {
        yield return new WaitForSeconds(8);
        if(GameObject.Find("Point Light").transform.position.z < -40)
        {
            SpawnMobs();
        }
        StartCoroutine("NightSpawn");
    }

    IEnumerator ActionSetFalse()

    {
        yield return new WaitForSeconds(120);
        ActionSpawn = 0;
    }

    public void SpawnMobs()
    {
        if(ActionSpawn == 0)
        {
            Transform PlayerPosition = GameObject.Find("Player").transform;

            float coordinate_x = PlayerPosition.position.x;
            float coordinate_y = PlayerPosition.position.y;

            int random = UnityEngine.Random.Range(1, 6);

            int random_2 = 0;
            int random_mob = 0;
            while(random > 0)
            {
                coordinate_x = coordinate_x + UnityEngine.Random.Range(10, 15);
                coordinate_y = coordinate_y + UnityEngine.Random.Range(10, 15);

                random_2 = UnityEngine.Random.Range(1, 4);
                random_mob = UnityEngine.Random.Range(0, MobsAttack.Length);
                if (random_2 == 1)
                {
                    GameObject Mob = Instantiate(MobsAttack[random_mob], new Vector3(coordinate_x, PlayerPosition.position.y), Quaternion.identity);
                    Mob.transform.SetParent(gameObject.transform);
                }
                if (random_2 == 2)
                {
                    GameObject Mob = Instantiate(MobsAttack[random_mob], new Vector3(PlayerPosition.position.x, coordinate_y), Quaternion.identity);
                    Mob.transform.SetParent(gameObject.transform);
                }
                if (random_2 == 3)
                {
                    GameObject Mob = Instantiate(MobsAttack[random_mob], new Vector3(coordinate_x, coordinate_y), Quaternion.identity);
                    Mob.transform.SetParent(gameObject.transform);
                }

                random--;
            }
        }

        ActionSpawn = 1;
        StartCoroutine("ActionSetFalse");
    }
}
