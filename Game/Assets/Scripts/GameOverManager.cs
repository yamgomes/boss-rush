using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public Text finalText;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("win") == 0){
            finalText.text = "O inimigo te derrotou em " + PlayerPrefs.GetInt("time") + " segundos";
        } else {
            finalText.text = "O inimigo foi derrotado em " + PlayerPrefs.GetInt("time") + " segundos!";
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Restart()
    {
        SceneManager.LoadScene("Menu");
    }
}
