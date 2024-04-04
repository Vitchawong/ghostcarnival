using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using static Unity.VisualScripting.Member;

public class Talisman : MonoBehaviour
{
    public Vector3 iniPos;
    public GameObject gameManager;
    
    private bool isPlaying = false;
    private bool increase = false;
    // Start is called before the first frame update
    void Start()
    {
        iniPos = transform.position;
        gameManager = GameObject.FindGameObjectWithTag("GameController");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position != iniPos)
        {
            Debug.Log("Moved!");
            if (isPlaying == false)
            {
                gameObject.GetComponent<AudioSource>().Play();
                isPlaying = true;
            }
            if (increase == false)
            {
                gameManager.GetComponent<GameManagerScript>().AddTalismanScore();
                increase = true;
                foreach (MeshRenderer mr in GetComponentsInChildren<MeshRenderer>())
                {
                    mr.enabled = false;
                }


            }
            StartCoroutine(waitForSound());
        }

    }
    IEnumerator waitForSound()
    {
        yield return new WaitForSeconds(6);
        gameObject.SetActive(false);
    }

}
