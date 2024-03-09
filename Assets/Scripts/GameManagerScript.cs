using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManagerScript : MonoBehaviour
{
    public TextMeshProUGUI successText;
    public GameObject ball;
    // Start is called before the first frame update
    void Start()
    {
        successText.text = string.Empty;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
