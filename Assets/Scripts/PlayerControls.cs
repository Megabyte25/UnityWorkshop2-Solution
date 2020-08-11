using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    private Controls m_Controls;

    void OnEnable()
    {
        m_Controls.Enable();
    }

    void OnDisable()
    {
        m_Controls.Disable();
    }

    void Awake()
    {
        // Setup controls
        m_Controls = new Controls();
        
        // TODO: Implement the Jump callback
        // TODO: Get a reference to PlayerController
    }

    void Update()
    {
        // TODO: Read the "Move" ation values using ReadValue<Vector2>();
        // TODO: Set movement direction for player controller
    }
}
