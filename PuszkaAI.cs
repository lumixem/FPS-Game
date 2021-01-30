using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PuszkaAI : MonoBehaviour
{
    //public float puszkaDamage = 14;    
    //public float DistanceFromPlayer = 50.0f;
    //public float time = 2.0f;
    public float distance; 
    //public int puszkaHP = 70;
    //public int distanceToPlayer;
    //public float range;

    public AudioClip puszkaAttack;
    public Animator anim;
    private NavMeshPath path;
    private NavMeshAgent agent;
    private GameObject player;
    //private Transform playerTransform;  
    //public GameObject puszkaEnemy;
    Rigidbody rb;

    void Awake()
    {
        anim.SetBool("atak", false);
        path = new NavMeshPath();
        agent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = puszkaAttack;
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
       
        distance = Vector3.Distance(player.transform.position, agent.transform.position);

        if (distance <= 2)
        {
            Debug.Log("Puszka is close" + distance);
            StartCoroutine(PuszkaAttack());
        }    
    }

    IEnumerator PuszkaAttack()
    {
        GetComponent<NavMeshAgent>().updatePosition = false;
        anim.SetBool("atak", true);
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("atak", false);
        GetComponent<NavMeshAgent>().updatePosition = true;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            GetComponent<AudioSource>().Play();                       
            Debug.Log("Shroom Collision");
            player.GetComponent<HP>().TakeDamage(14);
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.gameObject.tag == "Player")
    //    {
    //        rb.velocity = Vector3.zero;
    //        yield return WaitForSeconds(5);
    //    }
    //}    
    
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
}
