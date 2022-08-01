using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MovePlayer : MonoBehaviour
{
    public float kecepatan, lompat;
    Rigidbody rb;
    Animator anime;

    public Transform putaranPlayer;

    int life;
    public TextMeshProUGUI lifeText;
    public GameObject loseTextObject;

    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anime = GetComponent<Animator>();
    }
    
    void Start()
    {
        life = 3;

        SetLifeText();
        loseTextObject.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Bergerak();

        if(Input.GetKey(KeyCode.UpArrow))
        {
            Melompat();
        }
    }

    void Bergerak()
    {
        float gerak = Input.GetAxis("Horizontal");
        rb.velocity = Vector3.right * gerak * kecepatan;
        anime.SetFloat("Kecepatan", Mathf.Abs(gerak), 0.1f, Time.deltaTime);
        putaranPlayer.localEulerAngles = new Vector3(0, gerak * 90, 0);
    }

    void Melompat()
    {
        rb.velocity = new Vector3(0, lompat);
    }
 
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("virus"))
        {
            //Time.timeScale = 0;
            //Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
       if (other.gameObject.CompareTag("virus"))
        {
            other.gameObject.SetActive(false);
            life = life - 1;
            SetLifeText();
        }
    }

    void SetLifeText()
    {
        lifeText.text = "Life: " + life.ToString();

        if (life <= 0)
        {
            // Set the text value of your 'loseText'
            loseTextObject.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
