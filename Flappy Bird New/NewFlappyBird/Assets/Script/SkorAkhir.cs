using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkorAkhir : MonoBehaviour
{
    public GameObject ScoreText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.name == "skorAkhir")
        {
            GetComponent<Text>().text = ScoreText.GetComponent<skor>().score.ToString();
        } else if (gameObject.name == "highScore")
        {
            GetComponent<Text>().text = PlayerPrefs.GetInt("highScore").ToString();
        }
    }
}
