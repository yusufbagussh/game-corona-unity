using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerSetting : MonoBehaviour
{
    public Text TextTimer;
    public float Waktu;

    public bool GameAktif = true;
    public GameObject CanvasKalah;
    // Start is called before the first frame update
    void Start()
    {

    }

    void SetText()
    {
        int Menit = Mathf.FloorToInt(Waktu / 60);
        int Detik = Mathf.FloorToInt(Waktu % 60);
        TextTimer.text = Menit.ToString("00") + " : " + Detik.ToString("00");
    }

    float s;
    // Update is called once per frame
    void Update()
    {
        //Waktu Bertambah
        /*SetText();

        s += Time.deltaTime;
        if(s >= 1)
        {
            Waktu++;
            s = 0;
        }*/

        if(GameAktif)
        {
            s += Time.deltaTime;
            if(s >= 1)
            {
                Waktu--;
                s = 0;
            }
        }

        if(GameAktif && Waktu <= 0)
        {
            Debug.Log("Game Lose");
            CanvasKalah.SetActive(true);
            GameAktif = false;
        }

        SetText();
    }
}
