using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    List<GameObject> players;
    int playersAlive;

    GameObject winner;

    public Text endGameText;
    public Text pausedText;

    bool gameEnded = false;
    bool paused = false;

    // Use this for initialization
    void Start() {

        players = new List<GameObject>();

        if (GameObject.FindGameObjectWithTag("Player1") != null)
        {
            players.Add(GameObject.FindGameObjectWithTag("Player1"));
        }

        if (GameObject.FindGameObjectWithTag("Player2") != null)
        {
            players.Add(GameObject.FindGameObjectWithTag("Player2"));
        }

        if (GameObject.FindGameObjectWithTag("Player3") != null)
        {
            players.Add(GameObject.FindGameObjectWithTag("Player3"));
        }

        if (GameObject.FindGameObjectWithTag("Player4") != null)
        {
            players.Add(GameObject.FindGameObjectWithTag("Player4"));
        }

        playersAlive = players.Count;
    }

    void Update()
    {

        if (playersAlive == 1)
        {
            EndGame();
        }

        if (Input.GetButtonDown("UniversalY"))
        {
            Debug.Log("Pause");
            PauseGame();
        }

        if (gameEnded)
        {
            Time.timeScale = 0;
            if (Input.GetButton("P1_A"))
            {
                Application.LoadLevel(Application.loadedLevel);

                endGameText.gameObject.SetActive(false);
                gameEnded = false;

                StartNewGame();
            }
            if (Input.GetButton("P1_B"))
            {
                //Application.LoadLevel( MAIN MENU );

                endGameText.gameObject.SetActive(false);
                gameEnded = false;
            }
        }

    }

    public void KillPlayer(string tag)
    {
        playersAlive--;
        players.Remove(GameObject.FindGameObjectWithTag(tag));
        playersAlive = players.Count;
    }

    void EndGame()
    {
        if (winner == null)
        {
            foreach (GameObject player in players)
            {
                winner = player.gameObject;
            }
        }
        endGameText.gameObject.SetActive(true);

        gameEnded = true;
        Camera.main.transform.SetPositionAndRotation(new Vector3(winner.transform.position.x, winner.transform.position.y, -5), Quaternion.identity);
    }

    void StartNewGame()
    {
        Time.timeScale = 1;
        endGameText.gameObject.SetActive(false);
    }

    void PauseGame()
    {
        if (!paused)
        {
            Debug.Log("Paused");
            pausedText.gameObject.SetActive(true);
            Time.timeScale = 0;
            paused = true;
        }
        else {
            Debug.Log("Unpaused");
            pausedText.gameObject.SetActive(false);
            Time.timeScale = 1;
            paused = false;
        }
    }
}
