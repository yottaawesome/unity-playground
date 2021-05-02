using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField]
    private float ScreenWidthInUnityUnits = 16f;

    [SerializeField]
    private float PaddleMinX = 1.0f;

    [SerializeField]
    private float PaddleMaxX = 15f;

    GameStatus gameStatus;
    Ball ball;

    // Start is called before the first frame update
    void Start() 
    {
        gameStatus = FindObjectOfType<GameStatus>();
        ball = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        // x = Input.mousePosition.x / Screen.width = position of mouse as a decimal of the screen width
        // y = x * ScreenWidthInUnityUnits = Convert x to Unity units;
        gameObject.transform.position =
            new Vector2(
                GetXPos(),
                gameObject.transform.position.y
            );
    }

    private float GetXPos()
    {
        float newXPosition = 0;
        if (gameStatus.IsAutoplayEnabled())
        {
            newXPosition = ball.transform.position.x;
        }
        else
        {
            newXPosition = Input.mousePosition.x / Screen.width * ScreenWidthInUnityUnits;
        }
        newXPosition = Mathf.Clamp(newXPosition, PaddleMinX, PaddleMaxX);
        return newXPosition;
    }

}
