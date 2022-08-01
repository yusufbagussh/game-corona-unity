using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class home : MonoBehaviour
{
    // public void GoToMenu(){
    //     Application.LoadLevel ("MenuUtama");
    // }
        public void LoadScene(string scenename){
        SceneManager.LoadScene (scenename);
    }
}
