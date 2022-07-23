using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    int attack = 0;
    int rotations = 0;
    int enemyHealth = 10;
    public GameObject platform;
    public GameObject terrain;


    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Attack", 5f, 10f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Attack()
    {
        switch (attack)
        {
            case 0:
                Debug.Log("Attack 1");
                break;
            case 1:
                Debug.Log("Attack 2");
                break;
            case 2:
                Debug.Log("Attack 3");
                rotations++;
                break;

            default:
                break;
        }
        Debug.Log(rotations);
        if (rotations == 0)
        {
            rotations = 0;
            Vector3 pos = terrain.transform.GetChild(Random.Range(0, 18)).transform.position;
            Debug.Log(pos);
            platform.transform.position = new Vector3(pos.x, platform.transform.position.y, pos.z);

        }
        attack += (attack + 1) % 3;

    }
    void Damage()
    {
        Debug.Log("Damage");
        enemyHealth -= 1;
        if (enemyHealth <= 0)
        {
            Debug.Log("Enemy Dead");
            GameOver();
        }
    }
    void GameOver()
    {
        Debug.Log("Game Over");
    }
}

public enum GameState
{
    Playing,
    GameOver,
    Start
}
