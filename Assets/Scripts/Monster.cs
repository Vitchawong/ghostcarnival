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

    private bool isPlaying = false;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        audioSouce.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.GetComponent<GameManagerScript>().count > 0)
        {
            Debug.Log("Hunting");
            agent.SetDestination(player.transform.position);
        }
        //agent.SetDestination(player.transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.tag); 
        if (isPlaying == false)
        {
            audioSouce.clip = nom;
            audioSouce.Play();
            isPlaying = true;
        }
        gameOver.SetActive(true);
    }
}
