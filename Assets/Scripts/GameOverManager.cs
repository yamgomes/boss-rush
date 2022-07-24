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
        if(!GameManager.GetInstance().GetVictory()){
            finalText.text = "Tente de novo!\nExiste esperança ";
        } else {
            finalText.text = "Muito bem!\nO inimigo foi derrotado!";
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
