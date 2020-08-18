using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    private PlayerInputActions m_PlayerInputActions;

    void OnEnable()
    {
        m_PlayerInputActions.Enable();
    }

    void OnDisable()
    {
        m_PlayerInputActions.Disable();
    }

    void Awake()
    {
        // Setup controls
        m_PlayerInputActions = new PlayerInputActions();
        
        // TODO: Implement the Jump callback
    }

    void Update()
    {
        // TODO: Read the "Move" action values using ReadValue<Vector2>();
    }

    // TODO: Implement a bunch of getters for the PlayerController to use
}
