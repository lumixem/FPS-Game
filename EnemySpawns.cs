//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class EnemySpawns : MonoBehaviour
//{
//    public GameObject kamikazeEnemy;
//    public GameObject shroomEnemy;
//    public GameObject puszkaEnemy;
//    public Transform player;

//    public int xPos;
//    public int zPos;
//    public int enemyCount;
//    public float Distance;

//    void Start()
//    {
//        //StartCoroutine(KamikazeGenerator());
//        StartCoroutine(ShroomGenerator());
//        //StartCoroutine(PuszkaGenerator());

//    }

//    void Update()
//    {
//        if (GameObject.Find("kamikazeEnemy") != null)
//        {
//            Distance = Vector3.Distance(player.transform.position, kamikazeEnemy.transform.position);
//        }

//        if (GameObject.Find("shroomEnemy") != null)
//        {
//            Distance = Vector3.Distance(player.transform.position, shroomEnemy.transform.position);
//        }
//    }

//    IEnumerator KamikazeGenerator()
//    {
//        while (enemyCount < 3)
//        {
//            xPos = Random.Range(21, 58);
//            zPos = Random.Range(10, 60);
//            GameObject obj = Instantiate(kamikazeEnemy, new Vector3(xPos, 1.3f, zPos), Quaternion.identity);
//            obj.name = "" + enemyCount;
//            obj.SetActive(true);
//            yield return new WaitForSeconds(Random.Range(1, 5));
//            enemyCount += 1;

//        }
//    }

//    IEnumerator ShroomGenerator()
//    {
//        while (enemyCount < 3)
//        {
//            xPos = Random.Range(21, 58);
//            zPos = Random.Range(10, 60);
//            GameObject obj = Instantiate(shroomEnemy, new Vector3(xPos, 1.3f, zPos), Quaternion.identity);
//            obj.name = "" + enemyCount;
//            obj.SetActive(true);
//            yield return new WaitForSeconds(Random.Range(1, 5));
//            enemyCount += 1;

//        }
//    }

//    IEnumerator PuszkaGenerator()
//    {
//        while (enemyCount < 3)
//        {
//            xPos = Random.Range(21, 58);
//            zPos = Random.Range(10, 60);
//            GameObject obj = Instantiate(puszkaEnemy, new Vector3(xPos, 1.3f, zPos), Quaternion.identity);
//            GameObject obj2 = Instantiate(puszkaEnemy, new Vector3(xPos, 1.3f, zPos), Quaternion.identity);
//            GameObject obj3 = Instantiate(puszkaEnemy, new Vector3(xPos, 1.3f, zPos), Quaternion.identity);
//            obj.name = "" + enemyCount;
//            obj.SetActive(true);
//            yield return new WaitForSeconds(Random.Range(1, 5));
//            enemyCount += 1;

//        }
//    }
//}
