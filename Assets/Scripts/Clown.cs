using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crown : MonoBehaviour
{
    public GameObject player;

    private Animator animator;
    private bool isClose;
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentLookAt = gameObject.transform.position;
        if ((player.transform.position - this.gameObject.transform.position).magnitude < 5f)
        {
            Vector3 targetPos = new Vector3(player.transform.position.x, gameObject.transform.position.y, player.transform.position.z);
            this.gameObject.transform.LookAt(targetPos);
            isClose = true;
            animator.SetBool("isClose", true);
            StartCoroutine(SetAlreadyPlayCoroutine());
        } else
        {
            this.gameObject.transform.SetPositionAndRotation(currentLookAt, Quaternion.Euler(0,-132,0));
            isClose = false;
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


