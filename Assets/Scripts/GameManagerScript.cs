using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManagerScript : MonoBehaviour
{
    public GameObject portal;
    public GameObject player;
    public GameObject xr;
    public AudioSource bgSound;

    private Vector3 pos = new Vector3(4.09f, 13.32f, 6.27f);
    // Start is called before the first frame update
    void Start()
    {
        //bgSound.Play();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log((player.transform.position - pos).magnitude);
        if ((player.transform.position - pos).magnitude < 3)
        {
            Debug.Log("here");
            xr.transform.position = new Vector3(-0.5f, 2f, -42.685f);
            xr.transform.rotation = Quaternion.Euler(0f,150f,0f);
            bgSound.Stop();
            //player.transform.position = new Vector3(18.8f, 0.505f, 60.424f);
        }
    }

    //private void FixedUpdate()
    //{

    //}

}
