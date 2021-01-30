using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShroomGenerator : MonoBehaviour
{
    public int enemyCount;
    float noSpawnRange = 2;
    List<Vector3> spawnedPositions = new List<Vector3>();

    public GameObject shroomEnemy;

    void Start()
    {
        StartCoroutine(ShroomGenerator());
    }

    IEnumerator ShroomGenerator()
    {
        while (enemyCount < 3)
        {
            yield return new WaitForSeconds(2);
            bool isUnique = false;
            GameObject obj = Instantiate(shroomEnemy);
            Vector3 spawnPosition = Vector3.zero;
            int whileBreak = 0;
            while (!isUnique)
            {
                spawnPosition = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
                for (int i = 0; i < spawnedPositions.Count; i++)
                {
                    if (Vector3.Distance(spawnedPositions[i], spawnPosition) < 0.2f)
                    {
                        isUnique = false;
                        break;
                    }
                    else
                    {
                        isUnique = true;
                    }
                }

                if(isUnique)
                {
                    break;
                }
                whileBreak++;

                if (whileBreak > 10)
                {
                    break;
                }
            }
            spawnedPositions.Add(spawnPosition);
            spawnPosition.Normalize();
            spawnPosition *= noSpawnRange;
            obj.transform.position = transform.position + spawnPosition;
            obj.name = "" + enemyCount;
            obj.SetActive(true);
            enemyCount += 1;

        }
    }
}
