using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Menu_script : MonoBehaviour
{
    public RectTransform effects_transform1;
    public RectTransform effects_transform2;
    public InputActionReference look;
    public float sensitivity = 1.0f;
    private Vector2 previousMousePosition;
    
    void Start()
    {
        look.action.Enable();
        previousMousePosition = look.action.ReadValue<Vector2>();
    }

    void Update()
    {
        Vector2 currentMousePosition = look.action.ReadValue<Vector2>();
        Vector2 deltaMouse = currentMousePosition - previousMousePosition;
        Vector3 newPosition = new Vector3(effects_transform1.anchoredPosition.x, effects_transform1.anchoredPosition.y, 0) + (new Vector3(deltaMouse.x, deltaMouse.y, 0) * sensitivity);
        effects_transform1.anchoredPosition = newPosition;
        newPosition = new Vector3(effects_transform2.anchoredPosition.x, effects_transform2.anchoredPosition.y, 0) + (new Vector3(deltaMouse.x, deltaMouse.y, 0) * sensitivity);
        effects_transform2.anchoredPosition = newPosition;
        previousMousePosition = currentMousePosition;
    }

    public void OnPlayButton(int scene)
    {
        SceneManager.LoadScene(scene);
    }
}
