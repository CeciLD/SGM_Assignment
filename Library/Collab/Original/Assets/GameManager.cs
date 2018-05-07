﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    List<GameObject> players;
    int playersAlive;

    GameObject winner;

    public Text endGameText;
    bool gameEnded = false;

	// Use this for initialization
	void Start () {

        players = new List<GameObject>();

        if (GameObject.FindGameObjectWithTag("Player1") != null)
        {
            players.Add(GameObject.FindGameObjectWithTag("Player1"));
            Debug.Log("Player added" + players.Count);
        }        

        if (GameObject.FindGameObjectWithTag("Player2") != null)
        {
            players.Add(GameObject.FindGameObjectWithTag("Player2"));
            Debug.Log("Player added" + players.Count);
        }

        if (GameObject.FindGameObjectWithTag("Player3") != null)
        {
            players.Add(GameObject.FindGameObjectWithTag("Player3"));
            Debug.Log("Player added" + players.Count);
        }

        if (GameObject.FindGameObjectWithTag("Player4") != null)
        {
            players.Add(GameObject.FindGameObjectWithTag("Player4"));
            Debug.Log("Player added" + players.Count);
        }

        playersAlive = players.Count;
    }

    public void KillPlayer(string tag)
    {
        playersAlive--;
        players.Remove(GameObject.FindGameObjectWithTag(tag));
    }

    void EndGame()
    {
        gameEnded = true;

        if(winner == null)
        {
            foreach(GameObject player in players)
            {
                winner = player.gameObject;
            }
        }
        endGameText.enabled = true;

        Time.timeScale = 0;
        Camera.main.transform.SetPositionAndRotation(new Vector3(winner.transform.position.x, winner.transform.position.y, -5), Quaternion.identity);

        endGameText.gameObject.SetActive(true);
    }

	// Update is called once per frame
	void Update () {
        
        if(playersAlive == 1)
        {
            EndGame();
        }

        if (gameEnded)
        {
            if (Input.GetButton("P1_A") || Input.GetKey(KeyCode.W))
            {
                Time.timeScale = 1;
                Application.LoadLevel(Application.loadedLevel);
                gameEnded = false;
            }
            if (Input.GetButton("P1_B"))
            {
                Time.timeScale = 1;

                gameEnded = false;
            }
        }
    }

}