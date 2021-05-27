using UnityEngine;
using TMPro;
using System;
using System.Collections;

public class GameStatus : MonoBehaviour
{
    [SerializeField]
    [Range(0.1f, 10f)]
    float gameSpeed = 1f;

    int currentScore = 0;
    TMPro.TextMeshProUGUI scoreText;
    TMPro.TextMeshProUGUI healthText;
    Player player;
    SceneLoader sceneLoader;

    // This is a singleton pattern. Note the canvas has been made
    // a child of this object to also make it a singleton. This
    // functionality could also be implemented as a static object
    // or static variable.
    private void Awake()
    {
        if (FindObjectsOfType<GameStatus>().Length > 1)
        {
            // There is potential for other objects to try to use
            // this object before it's destroyed (depending on the
            // execution order of the scripts), so set it to
            // inactive so it can't cause any mischief
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

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