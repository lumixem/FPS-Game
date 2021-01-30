using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShroomAI : MonoBehaviour
{
    float noSpawnRange = 2;
    //public float shroomDamage = 21;   
    //public float DistanceFromPlayer = 50.0f;
    //public float time = 2.0f;
    //public float Distance;
    //public int shroomHP = 150;
    public int enemyCount;
   
    //private Transform playerTransform;    
    //public GameObject shroomEnemy;
    public GameObject podgrzybEnemy;

    //Rigidbody rb;

    void Start()
    {
        StartCoroutine(PodgrzybGenerator());
    //    rb = GetComponent<Rigidbody>();
    //    playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    //void FixedUpdate()
    //{
    //    transform.LookAt(playerTransform.transform);
    //    float distancebetweenplayer = Vector3.Distance(transform.position, playerTransform.position);
    //    if (distancebetweenplayer < DistanceFromPlayer)
    //    {            
    //        transform.Translate(transform.forward * Time.deltaTime * 5);
    //    }

    //    Distance = Vector3.Distance(playerTransform.transform.position, transform.position);
    //}

    //public void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.name == "Player")
    //    {
    //        Debug.Log("Shroom Collision");                     
    //        playerTransform.GetComponent<HP>().TakeDamage(21);           
    //    }
    //}
    IEnumerator PodgrzybGenerator()
    {
        while (enemyCount < 1)
        {
            yield return new WaitForSeconds(5);
            GameObject obj = Instantiate(podgrzybEnemy);
            Vector3 spawnPosition = new Vector3(Random.Range(-1f,1f), 0, Random.Range(-1f, 1f));
            spawnPosition.Normalize();
            spawnPosition *= noSpawnRange;
            obj.transform.position = transform.position + spawnPosition;
            obj.name = "" + enemyCount;
            obj.SetActive(true);           
            enemyCount += 1;

        }
    }

    public float GetNoSpawnRange()
    {
        return noSpawnRange;
    }
}
