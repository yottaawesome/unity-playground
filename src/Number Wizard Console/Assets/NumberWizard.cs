using UnityEngine;
public enum GameState
{
    Running,
    Finished
}

// https://docs.unity3d.com/2021.1/Documentation/ScriptReference/MonoBehaviour.html
public class NumberWizard : MonoBehaviour
{
    private static GameState State = GameState.Running;
    private static uint MinNumber = 1;
    private static uint MaxNumber = 1000;

    private static uint CurrentMin = MinNumber;
    private static uint CurrentMax = MaxNumber;
    private static uint CurrentGuess = (MinNumber + MaxNumber) / 2;

    // Start is called before the first frame update
    // https://docs.unity3d.com/2021.1/Documentation/ScriptReference/MonoBehaviour.Start.html
    void Start()
    {
        StartNewGame();
    }

    void UpdateGuess()
    {
        CurrentGuess = (CurrentMax + CurrentMin) / 2;
        Debug.Log($"Is your number {CurrentGuess}?");
    }

    void StartNewGame()
    {
        Debug.Log("Welcome to Number Wizard!");
        Debug.Log($"Pick a number between {MinNumber} and {MaxNumber}, and I'll try to guess your number!");
        Debug.Log("With each of my guesses, you'll have to tell me whether your number is higher or lower, and I'll update my guess!");
        Debug.Log("Controls: up = higher, down = lower, enter = correct");
        Debug.Log("Ok, let's play! Pick a number and I'll try to guess it...");
        State = GameState.Running;
        CurrentMax = MaxNumber;
        CurrentMin = MinNumber;
        UpdateGuess();
    }

    // Update is called once per frame
    // https://docs.unity3d.com/2021.1/Documentation/ScriptReference/MonoBehaviour.Update.html
    void Update()
    {
        switch (State)
        {
            case GameState.Running:
            {
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    Debug.Log("Your number is higher, eh?");
                    CurrentMin = CurrentGuess;
                    UpdateGuess();
                }
                else if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    Debug.Log("Your number is lower, eh?");
                    CurrentMax = CurrentGuess;
                    UpdateGuess();
                }
                else if (Input.GetKeyDown(KeyCode.Return))
                {
                    Debug.Log("Great! Do you want to play again? (Hit Return if you do.)");
                    State = GameState.Finished;
                }
                break;
            }

            case GameState.Finished:
            {
                if (Input.GetKeyDown(KeyCode.Return))
                    StartNewGame();
                break;
            }
        }
    }
}
