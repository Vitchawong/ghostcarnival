using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crown : MonoBehaviour
{
    public GameObject player;
    public AudioSource AudioSource;

    private Animator animator;
    private AudioSource audioSource;
    private bool isClose;
    private bool isPlaying = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentLookAt = gameObject.transform.position;
        if ((player.transform.position - this.gameObject.transform.position).magnitude < 3f)
        {
            Vector3 targetPos = new Vector3(player.transform.position.x, gameObject.transform.position.y, player.transform.position.z);
            this.gameObject.transform.LookAt(targetPos);
            isClose = true; 
            animator.SetBool("isClose", true);
            if (isPlaying == false)
            {
                audioSource.PlayOneShot(AudioSource.clip);
                isPlaying = true;
            }
            StartCoroutine(SetAlreadyPlayCoroutine());
        } else
        {
            this.gameObject.transform.SetPositionAndRotation(currentLookAt, Quaternion.Euler(0,-132,0));
            isClose = false;
            isPlaying = false;
            animator.SetBool("alreadyPlay", false);
        }
        animator.SetBool("isClose", isClose);
    }
    private IEnumerator SetAlreadyPlayCoroutine()
    {
        yield return new WaitForSeconds(1f);
        animator.SetBool("alreadyPlay", true);
    }
}


