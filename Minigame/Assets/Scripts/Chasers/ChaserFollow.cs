using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaserFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float catchRange = 2f;
    [SerializeField] GameObject CaughtMenuUI;
    [SerializeField] AudioClip trappedSFX;

    private bool SoundOn;

    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        GetComponent<AudioSource>().Play();
        SoundOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        EngageTarget();
        //stops sfx when paused
        if (Time.timeScale <= 0f)
        {
            GetComponent<AudioSource>().Stop();
            SoundOn = false;
        }
        else
        {
            if (!SoundOn)
            {
                GetComponent<AudioSource>().Play();
                SoundOn = true;
            }
        }
    }

    private void EngageTarget()
    {
        if (distanceToTarget > navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
            
        }

        if (distanceToTarget <= catchRange)
        {
            GetComponent<AudioSource>().Stop();
            CatchTarget();
        }
    }

    private void CatchTarget()
    {
        Caught.GameOver = true;
        CaughtMenuUI.SetActive(true);
        Debug.Log("caught");
    }

    private void ChaseTarget()
    {
        navMeshAgent.SetDestination(target.position);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Trap")
        {
            Score.EnemyScore++;
            AudioSource audio = GetComponent<AudioSource>();
            audio.clip = trappedSFX;
            audio.Play();//cant get it to play
            Destroy(other.gameObject);
            Destroy(gameObject);



        }
    }
}
