using UnityEngine;
using UnityEngine.InputSystem;

public class pause : MonoBehaviour
{
    public RectTransform effects_transform;
    public InputActionReference look;
    public InputActionReference pauseAction;
    public float sensitivity = 1.0f;
    private Vector2 previousMousePosition;

    public GameObject Pause_Menu;

    public GameObject Die_Menu;

    Player player;
    
    void Start()
    {
        look.action.Enable();
        pauseAction.action.Enable();
        pauseAction.action.performed += PauseGame;
        previousMousePosition = Input.mousePosition;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void PauseGame(InputAction.CallbackContext obj)
    {
        Pause_Menu.SetActive(!Pause_Menu.activeSelf);
    }

    void Update()
    {
        Vector2 currentMousePosition = look.action.ReadValue<Vector2>();
        Vector2 deltaMouse = currentMousePosition - previousMousePosition;
        Vector3 newPosition = new Vector3(effects_transform.anchoredPosition.x, effects_transform.anchoredPosition.y, 0) + (new Vector3(deltaMouse.x, deltaMouse.y, 0) * sensitivity);
        effects_transform.anchoredPosition = newPosition;
        previousMousePosition = currentMousePosition;

        if (player.IsDead) {
            Die_Menu.SetActive(true);
        }
    }
}
