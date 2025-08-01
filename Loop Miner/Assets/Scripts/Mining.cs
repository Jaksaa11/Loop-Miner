using UnityEngine;
using UnityEngine.InputSystem;

public class Mining : MonoBehaviour
{
    [SerializeField] LayerMask groundLayer;
    [SerializeField] int damage;
    private void FixedUpdate()
    {
        Debug.DrawRay(transform.position,-transform.up,Color.red);
    }

    public void Mine(InputAction.CallbackContext con)
    {
        if (con.performed)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, -transform.up, 0.3f, groundLayer);

            if (hit.collider != null)
            {
                hit.collider.gameObject.GetComponent<Blocks>().TakeDamage(damage);
            }
        }
        
    }
}
