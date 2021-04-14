using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField]
    private float ScreenWidthInUnityUnits = 16f;

    [SerializeField]
    private float PaddleMinX = 1.0f;

    [SerializeField]
    private float PaddleMaxX = 15f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // x = Input.mousePosition.x / Screen.width = position of mouse as a decimal of the screen width
        // y = x * ScreenWidthInUnityUnits = Convert x to Unity units;

        float newXPosition = Input.mousePosition.x / Screen.width * ScreenWidthInUnityUnits;
        newXPosition = Mathf.Clamp(newXPosition, PaddleMinX, PaddleMaxX);
        gameObject.transform.position =
            new Vector2(
                newXPosition,
                gameObject.transform.position.y
            );
    }
}
