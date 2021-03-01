using UnityEngine;

public class NumberWizard : MonoBehaviour
{
    private static uint MinNumber = 1;
    private static uint MaxNumber = 1000;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Welcome to Number Wizard!");
        Debug.Log($"Pick a number between {MinNumber} and {MaxNumber}!");
        Debug.Log("Number Wizard will try to guess your number!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
