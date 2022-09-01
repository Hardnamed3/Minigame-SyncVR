using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] gameObjects;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int random = Random.Range(0, gameObjects.Length+1);//spawn random item
            Vector3 randomSpawnPosition = new Vector3(Random.Range(-24, 24), 4, Random.Range(-30, 13));//randomly moving spawner


            Instantiate(gameObjects[random], randomSpawnPosition, Quaternion.identity);
        }
    }
}
