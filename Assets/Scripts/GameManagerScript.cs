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
    public AudioSource audio;
    public TextMeshProUGUI ScoreText;
    public bool portalOpen = false;
    public GameObject monster;
    public GameObject exitPortal;

    // Sound Effect
    public AudioClip monScream;
    public AudioClip huantedBg;

    public int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        audio.Play();

    }

    // Update is called once per frame
    void Update()
    {
        if (portalOpen == true)
        {
            audio.clip = huantedBg;
            StartCoroutine(waitForBg());
        }
    }

    public void AddTalismanScore()
    {
        count++;
        string text = "Talisman Collected: " + count + "/8";
        ScoreText.text = text;
        if (count == 1)
        {
            StartCoroutine(waitForSound());
            monster.GetComponent<Monster>().ChangeMonsterState("Hunting");
        }
        else if (count == 8)
        {
            text = "Exit Gate has been open!";
            ScoreText.text = text;
            exitPortal.SetActive(true);
        }
    }

    public void OpenPortal()
    {
        portalOpen = true;
    }

    IEnumerator waitForSound()
    {
        yield return new WaitForSeconds(6);
        audio.PlayOneShot(monScream);
    }

    IEnumerator waitForBg()
    {
        yield return new WaitForSeconds(2);
        audio.Play();
        portalOpen = false;
    }


}
