using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class KamikazeAI : MonoBehaviour
{
    public float kamikazeDamage = 34;   
    public float DistanceFromPlayer = 50.0f;
    public float time = 2.0f;
    public float Distance;
    public int kamikazeHP = 350;
    
    public AudioClip kamikazeExplosionSound;
    private NavMeshAgent agent;
    private GameObject player;
    private Transform playerTransform;
    public GameObject kamikazeExplosion;
    public GameObject kamikazeEnemy;
    Rigidbody rb;
    
    private Vector3 smoothVelocity = Vector3.zero;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = kamikazeExplosionSound;
        GetComponent<NavMeshAgent>().speed = Random.Range(2f, 5f);
        agent.updateRotation = true;
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody>();               
    }

    void Update()
    {
        if (agent.isOnNavMesh)
        {
            agent.SetDestination(player.transform.position);           
        }
    }
    
    public void OnCollisionEnter(Collision collision)
    {       
        if (collision.gameObject.name == "Player")
        {
            GetComponent<AudioSource>().Play();          
            Debug.Log("Kamikaze Collision");
            Destroy(this.gameObject);
            player.GetComponent<HP>().TakeDamage(34);           
            GameObject GObj = Instantiate(kamikazeExplosion);
            GObj.transform.position = transform.position;
        }
    }
}

