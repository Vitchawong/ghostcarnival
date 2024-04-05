using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    public GameObject player;
    public GameObject gameManager;
    public AudioSource audioSouce;
    public AudioClip nom;
    private NavMeshAgent agent;
    public GameObject gameOver;
    public string monState;

    private bool isPlaying = false;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        audioSouce.Play();
        monState = "Idle";
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(monState);
        if (monState == "Hunting")
        {
            agent.SetDestination(player.transform.position);
            agent.isStopped = false;
            gameObject.GetComponent<Animator>().SetBool("isIdle", false);
            StartCoroutine(Hunting());
        } else if (monState == "Idle")
        {
            gameObject.GetComponent<Animator>().SetBool("isIdle", true);

            agent.isStopped = true;
            StartCoroutine(Idling());
        }
        //agent.SetDestination(player.transform.position);
    }

    public void ChangeMonsterState(string state)
    {
        Debug.Log("CHANGING STATE!");
        Debug.Log(monState);
        monState = state;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "Player")
        {
            if (isPlaying == false)
            {
                audioSouce.clip = nom;
                audioSouce.PlayOneShot(audioSouce.clip);
                isPlaying = true;
                gameOver.SetActive(true);
            }

        }
        if (other.gameObject.tag == "Lantern")
        {
            Debug.Log("HIT");
            StartCoroutine(MonsterStun());
        }
        //gameOver.SetActive(true);
    }

    IEnumerator Hunting()
    {
        yield return new WaitForSeconds(30);
        ChangeMonsterState("Idle");
    }

    IEnumerator Idling()
    {
        yield return new WaitForSeconds(10);
        ChangeMonsterState("Hunting");
    }

    IEnumerator MonsterStun()
    {
        ChangeMonsterState("Idle");
        gameObject.GetComponent<Animator>().SetBool("isIdle", true);
        yield return new WaitForSeconds(5);
        ChangeMonsterState("Hunting");
    }
}
