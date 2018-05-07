using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathScript : MonoBehaviour {

    public GameManager gm;

    public Text Player1Lives;
    public Text Player2Lives;
    public Text Player3Lives;
    public Text Player4Lives;

    int lives;

    public Vector3[] spawnPoints;

    GameObject thisPlayer;

    void Awake()
    {
        Player1Lives = GameObject.Find("BluePlayerLives").GetComponent<Text>();
        Player2Lives = GameObject.Find("OrangePlayerLives").GetComponent<Text>();
        Player3Lives = GameObject.Find("GreenPlayerLives").GetComponent<Text>();
        Player4Lives = GameObject.Find("PurplePlayerLives").GetComponent<Text>();

        thisPlayer = this.gameObject;
        spawnPoints = new Vector3[4];

        lives = 3;
        spawnPoints[0] = new Vector3(-30, 13, 0);
        spawnPoints[1] = new Vector3(-16, 13, 0);
        spawnPoints[2] = new Vector3(8, 13, 0);
        spawnPoints[3] = new Vector3(30, 13, 0);
    }

    void Update()
    {
        if(lives == 0)
        {
            Destroy(this.gameObject);
            gm.KillPlayer(this.gameObject.tag);
        }
    }

	void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject.tag == "Water")
        {
            Invoke("Respawn", 1);
            RemoveLife();
        }
    }

    void Respawn()
    {
        thisPlayer.transform.position = spawnPoints[RandomValue()];
    }

    int RandomValue()
    {
        int value = Random.Range(0, 3);
        return value;
    }

    void RemoveLife()
    {
        lives--;

        if (this.gameObject.tag == "Player1")
        {
            Player1Lives.text = lives + "";
        }
        if (this.gameObject.tag == "Player2")
        {
            Player2Lives.text = lives + "";
        }
        if (this.gameObject.tag == "Player3")
        {
            Player3Lives.text = lives + "";
        }
        if (this.gameObject.tag == "Player4")
        {
            Player4Lives.text = lives + "";
        }
    }
}
