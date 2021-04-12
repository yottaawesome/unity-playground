using UnityEngine;

public class LoseCollider : MonoBehaviour
{
    [SerializeField]
    SceneLoader sceneLoader;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        sceneLoader.GameOver();
    }
}
