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
                NextLevel();
                break;
            case "Fuel":
                Debug.Log("Fuel");
                break;
            default:
                ReloadLevel();
                
                break;
        }
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
        
    }
}
