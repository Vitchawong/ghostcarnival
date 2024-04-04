using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject xr;
    public GameObject gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Renderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.GetComponent<GameManagerScript>().portalOpen == true) 
        {
            Debug.Log("OPEN");
            gameObject.GetComponent<Renderer>().enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            xr.transform.position = new Vector3(-1f, 2f, -42.685f);
            xr.transform.rotation = Quaternion.Euler(0f, 150f, 0f);
        }
        Debug.Log(other.gameObject.tag);
    }

}
