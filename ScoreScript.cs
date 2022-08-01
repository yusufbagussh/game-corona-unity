using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    public float score;
    public Text scoreUI;

    public GameObject winTextObject;
    // Start is called before the first frame update
    void Start()
    {
        winTextObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("virus"))
        {
            score += 100;
            scoreUI.text = "Score : " + score.ToString();
            Destroy(collision.collider.gameObject);
            if (score >= 1000)
            {
                // Set the text value of your 'winText'
                winTextObject.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }
}
