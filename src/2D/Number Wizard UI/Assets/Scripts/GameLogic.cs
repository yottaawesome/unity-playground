using TMPro;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    private static uint MinNumber = 1;
    private static uint MaxNumber = 1000;

    private static uint CurrentMin = MinNumber;
    private static uint CurrentMax = MaxNumber + 1;
    private static uint CurrentGuess = (MinNumber + MaxNumber) / 2;
    private TextMeshProUGUI label;

    void Start() 
    {
        MinNumber = 1;
        MaxNumber = 1000;
        CurrentMin = MinNumber;
        CurrentMax = MaxNumber + 1;
        CurrentGuess = (MinNumber + MaxNumber) / 2;
        label = GameObject.Find("Guess Label").GetComponent<TextMeshProUGUI>();
        
        UpdateGuess();
    }

    void Update() { }

    public void Higher()
    {
        CurrentMin = CurrentGuess;
        UpdateGuess();
    }

    public void Lower()
    {
        CurrentMax = CurrentGuess;
        UpdateGuess();
    }

    void UpdateGuess()
    {
        CurrentGuess = (CurrentMax + CurrentMin) / 2;
        label.SetText(CurrentGuess.ToString());
    }
}
