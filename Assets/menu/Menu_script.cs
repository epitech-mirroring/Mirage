using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_script : MonoBehaviour
{
    public void OnPlayButton(int scene)
    {
        SceneManager.LoadScene(scene);
    }
}
