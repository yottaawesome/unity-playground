using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    // Config
    [Header("General")]
    [SerializeField]
    float secondsLoadDelay = 3f;

    // State
    int currentSceneIndex;

    // Start is called before the first frame update
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 0)
            StartCoroutine(LoadStartScene());
    }

    // Update is called once per frame
    void Update() { }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex++);
    }

    private IEnumerator LoadStartScene()
    {
        yield return new WaitForSeconds(secondsLoadDelay);
        LoadNextScene();
    }
}
