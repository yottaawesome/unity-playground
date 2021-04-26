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
        scoreText = GameObject
            .FindGameObjectWithTag("ScoreText")
            .GetComponent<TMPro.TextMeshProUGUI>();
        scoreText.text = currentScore.ToString();
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
