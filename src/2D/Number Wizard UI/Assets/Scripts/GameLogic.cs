using TMPro;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    [SerializeField]
    private uint MinNumber = 1;
    [SerializeField]
    private uint MaxNumber = 1000;
    [SerializeField]
    private TextMeshProUGUI label;

    private uint CurrentMin;
    private uint CurrentMax;
    private uint CurrentGuess;
    

    void Start() 
    {
        MinNumber = 1;
        MaxNumber = 1000;
        CurrentMin = MinNumber;
        CurrentMax = MaxNumber + 1;
        
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
