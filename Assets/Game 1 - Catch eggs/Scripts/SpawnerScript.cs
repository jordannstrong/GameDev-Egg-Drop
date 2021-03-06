using UnityEngine;
using System.Collections;

public class SpawnerScript : MonoBehaviour {

    public Transform eggPrefab;

    private float nextEggTime = 0.0f;
    private float spawnRate;
 	
	void Awake()
	{
		switch(gameObject.name)
		{
		case "Spawner":
			spawnRate = 1.5f;
			break; 
		case "Gold Spawner":
			spawnRate = 10.0f;
			break;
		case "Rock Spawner":
			spawnRate = 6.0f;
			break;
		default:
			break;
		}
	}

	void Update () {
        if (nextEggTime < Time.time)
        {
            SpawnEgg();
            nextEggTime = Time.time + spawnRate;

            //Speed up the spawnrate for the next egg
            spawnRate *= 0.98f;
            spawnRate = Mathf.Clamp(spawnRate, 0.3f, 99f);
        }
	}

    void SpawnEgg()
    {
        float addXPos = Random.Range(-1.6f, 1.6f);
        Vector3 spawnPos = transform.position + new Vector3(addXPos,0,0);
		Instantiate(eggPrefab, spawnPos, Quaternion.Euler(-90, 0, 0));
    }
}
