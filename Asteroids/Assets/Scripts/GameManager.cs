using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    [HideInInspector] public int lifes = 1;
    [HideInInspector] public int score = 0;
    public int nrOfAsteroidsInScene = 0;

    public GameObject player;

    public float respawnTime = 3f;

    public TextMeshProUGUI scoreTxt;
    public TextMeshProUGUI lifesTxt;

    public GameObject gameOverScreen;

    private void Awake()
    {
        // There must only be one instance of this class
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        scoreTxt.text = score.ToString();
        lifesTxt.text = lifes.ToString();
    }

    public void AddScore(int score)
    {
        this.score += score;
        scoreTxt.text = score.ToString();
    }

    public void RemoveLife()
    {
        lifes--;
        lifesTxt.text = lifes.ToString();
        if (lifes <= 0)
        {
            lifes = 0;
            GameOver();
        }
        else
        {
            Invoke(nameof(Respawn), respawnTime);
        }
    }

    private void Respawn()
    {
        player.transform.position = Vector3.zero;
        player.SetActive(true);
    }

    private void GameOver()
    {
        gameOverScreen.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
