using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectCounter : MonoBehaviour
{
    public string objectTag = "PrizeObject";

    private int objectCount;

    void Start()
    {
        objectCount = GameObject.FindGameObjectsWithTag(objectTag).Length;
    }

    public void ObjectDestroyed()
    {
        objectCount--;

        if (objectCount <= 0)
        {
            RestartScene();
        }
    }

    private void RestartScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
