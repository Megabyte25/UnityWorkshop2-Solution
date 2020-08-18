using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerInputHandler playerInputHandler;
    public float moveSpeed;
    public float angularSpeed;
    public float jumpForce;
    public ForceMode forceMode;

    private Rigidbody m_Rigidbody;

    private void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        playerInputHandler.onJumpEvent.AddListener(Jump);
    }

    private void OnDisable()
    {
        playerInputHandler.onJumpEvent.RemoveListener(Jump);
    }

    void Update()
    {
        Vector2 moveDirection = playerInputHandler.GetMoveDirection();
        Move(moveDirection);
        LookAt(moveDirection);
    }

    private void Move(Vector2 moveDirection)
    {
        // Convert Vector2 to a Vector3 (keeping y-value to 0)
        Vector3 direction = new Vector3(moveDirection.x, 0f, moveDirection.y);
        direction = Vector3.ClampMagnitude(direction, 1f);

        // Translate towards the computed direction vector
        transform.Translate(direction * moveSpeed * Time.deltaTime, Space.World);
    }

    private void LookAt(Vector2 moveDirection)
    {
        // Do not rotate if there is no magnitude
        if (moveDirection != Vector2.zero)
        {
            // Incrementally rotate the game object such that its forward vector will align with the forward vector
            Vector3 direction = new Vector3(moveDirection.x, 0f, moveDirection.y);
            Quaternion targetRotation = Quaternion.LookRotation(direction, transform.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, angularSpeed * Time.deltaTime);
        }
    }

    private void Jump()
    {
        m_Rigidbody.AddForce(jumpForce * transform.up, forceMode);
    }
}
