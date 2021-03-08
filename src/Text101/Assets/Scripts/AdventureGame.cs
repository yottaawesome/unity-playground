using UnityEngine;
using UnityEngine.UI;

public class AdventureGame : MonoBehaviour
{
    // SerializeField makes this available in the Unity inspector
    [SerializeField]
    Text storyTextComponent;

    [SerializeField]
    State startingState;

    State state;

    // Start is called before the first frame update
    void Start()
    {
        state = startingState;
        storyTextComponent.text = state.GetStoryText();
    }

    // Update is called once per frame
    void Update()
    {
        ManageState();
    }

    void SetNextState(int index)
    {
        State[] nextStates = state.GetNextPossibleStates();
        if (nextStates == null)
        {
            Debug.LogWarning("No further states");
            return;
        }
        if (nextStates.Length <= index)
        {
            Debug.LogWarning("No option available");
            return;
        }

        state = state.GetNextPossibleStates()[index];
        storyTextComponent.text = state.GetStoryText();
    }

    void ManageState()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1))
            SetNextState(0);
        else if(Input.GetKeyDown(KeyCode.Keypad2))
            SetNextState(1);
        else if (Input.GetKeyDown(KeyCode.Keypad3))
            SetNextState(2);
    }
}
