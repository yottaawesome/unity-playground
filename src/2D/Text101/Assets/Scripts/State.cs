using UnityEngine;

// This allows us to create State from the Create menu
[CreateAssetMenu(menuName = "State")]
public class State : ScriptableObject
{
    [TextArea(10, 14)]
    [SerializeField]
    public string StoryText;

    [SerializeField]
    public State[] NextPossibleStates;

    public string GetStoryText()
    {
        return StoryText; 
    }

    public State[] GetNextPossibleStates()
    {
        return NextPossibleStates;
    }
}
