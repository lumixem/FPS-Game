using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CanAI : MonoBehaviour
{
    public float distance; 
    
    public AudioClip canAttack;
    public Animator anim;
    private NavMeshPath path;
    private NavMeshAgent agent;
    private GameObject player;
    
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
        GetComponent<AudioSource>().clip = canAttack;
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
            Debug.Log("Can is close" + distance);
            StartCoroutine(CanAttack());
        }    
    }

    IEnumerator CanAttack()
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
            Debug.Log("Can Collision");
            player.GetComponent<HP>().TakeDamage(14);
        }
    }    
}
