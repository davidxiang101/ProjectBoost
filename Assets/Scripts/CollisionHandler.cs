using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("OK");
                break;
            case "Finish":
                StartNextSequence();
                break;
            case "Fuel":
                Debug.Log("Fuel");
                break;
            default:
                StartCrashSquence();
                break;
        }
    }

    void StartCrashSquence()
    {
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", 1f);
    }

    void StartNextSequence()
    {
        GetComponent<Movement>().enabled = false;
        Invoke("NextLevel", 1f);
    }

    void NextLevel()
    {
        Debug.Log("Finished Level");
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int totalSceneCount = SceneManager.sceneCountInBuildSettings;
        int nextSceneIndex = (currentSceneIndex + 1) % totalSceneCount;
        SceneManager.LoadScene(nextSceneIndex);
    }

    void ReloadLevel()
    {
        Debug.Log("Reload Level");
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
