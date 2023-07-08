using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawn : MonoBehaviour
{
    public GameObject spawn,goldenEgg;
    public void SpawnPickup()
    {
        spawn.transform.position = new Vector2(spawn.transform.position.x, Random.Range(-6.7f, 0.46f));
        GameObject throwableWeapon = Instantiate(goldenEgg, spawn.transform.position, Quaternion.identity) as GameObject;
        throwableWeapon.name = "GEgg";
    }
}
