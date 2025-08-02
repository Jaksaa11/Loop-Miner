using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Mining : MonoBehaviour
{
    public static Mining instance;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private int damage;
    [SerializeField] private GameObject explosion;
    
    private void FixedUpdate()
    {
        Debug.DrawRay(transform.position,-transform.up,Color.red);
    }

    private void Awake()
    {
        instance = this;
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Core")
        {
            explosion.SetActive(true);
        }
    }

    public void ChangeDamage(int _damage)
    {
        damage=_damage;
    }
}
