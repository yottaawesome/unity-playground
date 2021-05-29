using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadStartScene()
    {
        //GameObject
        //    .FindGameObjectWithTag("GameStatus")
        //    ?.GetComponent<GameStatus>()
        //    .ResetGameSession();
        FindObjectOfType<GameStatus>()?.ResetGameSession();
        SceneManager.LoadScene(0);
    }

    public void LoadNextScene()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
            SceneManager.LoadScene(nextSceneIndex);
        else
            SceneManager.LoadScene(0);
    }

    public void LoadFirstPlayableScene()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit(0);
    }

    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings-1);
    }
}
