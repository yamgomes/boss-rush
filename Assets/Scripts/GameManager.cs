using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    int attack = 0;
    int rotations = 0;
    int enemyHealth = 20;
    int playerHealth = 3;
    public GameObject platform;
    public GameObject terrain;
    public Text warningText;
    public Text lifeText;
    public Image healthBar;
    public GameObject player;
    public GameObject missle;
    public GameObject[] meteorList;
    public float time = 0f;
    private void Awake()
    {
        instance = this;
    }
    public static GameManager GetInstance()
    {
        return instance;
    }

    void Start()
    {
        InvokeRepeating("Attack", 5f, 10f);
        PlayerPrefs.SetInt("win", 0);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        healthBar.fillAmount = (float)enemyHealth / 20;
        lifeText.text = "Vidas: " + playerHealth;
    }

    void Attack()
    {
        switch (attack)
        {
            case 0:
                warningText.text = "Chuva de meteoros";
                foreach (var meteor in meteorList)
                {
                    Vector3 position = GetRandomBlock();
                    position.y = 5;
                    Instantiate(meteor, position, Quaternion.identity);
                }
                break;
            case 1:
                // warningText.text = "Ataque";
                // Debug.Log("Attack 2");
                break;
            case 2:
                // warningText.text = "Rajada";
                // Debug.Log("Attack 3");
                rotations++;
                break;

            default:
                break;
        }
        if (rotations == 0)
        {
            rotations = 0;
            Vector3 pos = GetRandomBlock();
            platform.transform.position = new Vector3(pos.x, platform.transform.position.y, pos.z);

        }
        attack += (attack + 1) % 3;

    }
    public void DealDamage()
    {
        enemyHealth -= 1;
        platform.transform.position = new Vector3(platform.transform.position.x, platform.transform.position.y, platform.transform.position.z - 30);
        if (enemyHealth <= 0)
        {
            PlayerPrefs.SetInt("win", 1);
            GameOver();
        }

    }
    void GameOver()
    {
        PlayerPrefs.SetInt("time", (int)time);
        SceneManager.LoadScene("GameOver");

    }
    public void LoseHp()
    {
        playerHealth -= 1;
        if (playerHealth <= 0)
        {
            PlayerPrefs.SetInt("win", 0);
            GameOver();
        }
    }

    public Vector3 GetRandomBlock(){
        return terrain.transform.GetChild(Random.Range(0, 18)).transform.position;
    }
}

public enum GameState
{
    Playing,
    GameOver,
    Start
}
