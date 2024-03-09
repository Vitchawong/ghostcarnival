using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public TextMeshProUGUI successText;
    private Vector3 iniPos = new Vector3(3.737f, 12.8506f, -6.51f);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((iniPos - this.gameObject.transform.position).magnitude > 3)
        {
            StartCoroutine(ResetBallPosition());
        }
    }

    private IEnumerator ResetBallPosition()
    {
        yield return new WaitForSeconds(2);
        this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
        this.gameObject.transform.position = iniPos;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Cup")
        {
            successText.text = "Success!";
        }
    }
}
