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

    //public AudioClip kamikazeWalking;
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
        //playerTransform = GameObject.FindGameObjectWithTag("Player").transform;       
    }

    void Update()
    {
        if (agent.isOnNavMesh)
        {
            agent.SetDestination(player.transform.position);           
        }
    }

    //void playAudio()
    //{
    //    AudioSource audio = GetComponent<AudioSource>();
    //    if (!audio.isPlaying)
    //    {
    //        audio.clip = kamikazeExplosionSound;
    //        audio.Play();
    //    }
    //}

    //void FixedUpdate()
    //{
    //    transform.LookAt(playerTransform.transform);
    //    float distancebetweenplayer = Vector3.Distance(transform.position, playerTransform.position);
    //    if (distancebetweenplayer < DistanceFromPlayer)
    //    {
    //        //transform.position = Vector3.SmoothDamp(transform.position, player.position, ref smoothVelocity, time);
    //        //if (rb.velocity.normalized != transform.forward.normalized)
    //        //{
    //        //    rb.AddForce(transform.forward * 5, ForceMode.Acceleration);
    //        //}
    //        //else
    //        //{
    //        //    rb.AddForce(transform.forward, ForceMode.Acceleration);
    //        //}
    //        transform.Translate(transform.forward * Time.deltaTime * 5);
    //    }

    //    Distance = Vector3.Distance(playerTransform.transform.position, transform.position);
    //}

    public void OnCollisionEnter(Collision collision)
    {       
        if (collision.gameObject.name == "Player")
        {
            GetComponent<AudioSource>().Play();
            //playAudio();
            Debug.Log("Kamikaze Collision");
            //gameObject.SendMessage((isDamage)? "TakeDamage": "", SendMessageOptions.DontRequireReceiver);
            Destroy(this.gameObject);
            player.GetComponent<HP>().TakeDamage(34);           
            GameObject GObj = Instantiate(kamikazeExplosion);
            GObj.transform.position = transform.position;
        }
    }
}

