using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [Header("Player settings")]
    [SerializeField] private int speed;
    [Header("Player components")]
    [SerializeField] private Rigidbody2D rb;

    private float horizontal;

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocityY);
    }

    public void OnMove(InputAction.CallbackContext con)
    {
        horizontal = con.ReadValue<Vector2>().x;

    }
}
