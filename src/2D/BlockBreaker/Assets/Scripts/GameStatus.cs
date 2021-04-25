using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
    [SerializeField]
    [Range(0.1f, 10f)] 
    float gameSpeed = 1f;

    [SerializeField]
    int pointsPerBlockDestroyed = 1;

    int currentScore = 0;
    TMPro.TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start() 
    {
        scoreText = GameObject
            .FindGameObjectWithTag("ScoreText")
            .GetComponent<TMPro.TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed;
        scoreText.text = currentScore.ToString();
    }
}
