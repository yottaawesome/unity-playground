using TMPro;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    [SerializeField]
    private int MinNumber = 1;
    [SerializeField]
    private int MaxNumber = 1000;
    [SerializeField]
    private TextMeshProUGUI label;

    private int CurrentMin;
    private int CurrentMax;
    private int CurrentGuess;
    private System.Random rand;

    void Start() 
    {
        rand = new System.Random();
        MinNumber = 1;
        MaxNumber = 1000;
        CurrentMin = MinNumber;
        CurrentMax = MaxNumber + 1;
        
        UpdateGuess();
    }

    void Update() { }

    public void Higher()
    {
        CurrentMin = CurrentGuess == MaxNumber
            ? MaxNumber
            : CurrentGuess + 1;
        UpdateGuess();
    }

    public void Lower()
    {
        CurrentMax = CurrentGuess > 0
            ? CurrentGuess - 1
            : CurrentGuess;
        UpdateGuess();
    }

    void UpdateGuess()
    {
        CurrentGuess = rand.Next(CurrentMin, CurrentMax);
        label.SetText(CurrentGuess.ToString());
    }
}
