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
    private bool won = false;
    public Image healthBar;
    public GameObject player;
    public GameObject missle;
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
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = (float)enemyHealth / 20;
        lifeText.text = "Vidas: " + playerHealth;
    }

    void Attack()
    {
        switch (attack)
        {
            case 0:
                // warningText.text = "Chuva de meteoros";
                // Debug.Log("Attack 1");
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
            Vector3 pos = terrain.transform.GetChild(Random.Range(0, 18)).transform.position;
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
            Debug.Log("Enemy Dead");
            won = true;
            GameOver();
        }

    }
    void GameOver()
    {
        Debug.Log("Game Over");
        SceneManager.LoadScene("GameOver", LoadSceneMode.Additive);

    }
    public void LoseHp()
    {
        playerHealth -= 1;
        if (playerHealth <= 0)
        {
            GameOver();
        }
    }
    public bool GetVictory()
    {
        return won;
    }
}

public enum GameState
{
    Playing,
    GameOver,
    Start
}
