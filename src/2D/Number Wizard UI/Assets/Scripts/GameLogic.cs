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
        if(CurrentMax != CurrentMin)
        {
            CurrentMin = CurrentGuess == MaxNumber
                ? MaxNumber
                : CurrentGuess + 1;
            UpdateGuess();
        }
    }

    public void Lower()
    {
        if (CurrentMax != CurrentMin)
        {
            CurrentMax = CurrentGuess == MinNumber
                ? MinNumber
                : CurrentGuess - 1;
            UpdateGuess();
        }
    }

    void UpdateGuess()
    {
        if (CurrentMin > CurrentMax)
            CurrentMax = CurrentMin;
        CurrentGuess = rand.Next(CurrentMin, CurrentMax);
        label.SetText(CurrentGuess.ToString());
    }
}
