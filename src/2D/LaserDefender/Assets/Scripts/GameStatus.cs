using UnityEngine;
using TMPro;
using System;
using System.Collections;

public class GameStatus : Singleton<GameStatus>
{
    [SerializeField]
    [Range(0.1f, 10f)]
    float gameSpeed = 1f;

    int currentScore = 0;
    TMPro.TextMeshProUGUI scoreText;
    TMPro.TextMeshProUGUI healthText;
    Player player;
    SceneLoader sceneLoader;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello");
        scoreText = GameObject
            .FindGameObjectWithTag("ScoreText")
            .GetComponent<TMPro.TextMeshProUGUI>();
        scoreText.text = currentScore.ToString();

        healthText = GameObject
            .FindGameObjectWithTag("HealthText")
            .GetComponent<TMPro.TextMeshProUGUI>();

        player = GameObject
            .FindGameObjectWithTag("Player")
            ?.GetComponent<Player>();

        sceneLoader = GameObject
            .FindGameObjectWithTag("SceneLoader")
            .GetComponent<SceneLoader>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            player = GameObject
                .FindGameObjectWithTag("Player")
                ?.GetComponent<Player>();
        }

        Time.timeScale = gameSpeed;
        UpdateHealthText();
        scoreText.text = currentScore.ToString();
    }

    public void AddToScore(int points)
    {
        currentScore += points;
        scoreText.text = currentScore.ToString();
    }

    public void ResetGameSession()
    {
        Destroy(gameObject);
    }

    IEnumerator LoadDelayGameOver()
    {
        yield return new WaitForSeconds(2);
        player = null;
        sceneLoader?.GameOver();
    }

    public void PlayerDied()
    {
        StartCoroutine(LoadDelayGameOver());
    }

    private void UpdateHealthText()
    {
        if (player)
        {
            healthText.SetText(player.GetHealth().ToString());
        }
        else
        {
            healthText.SetText("0");
        }
    }
}
