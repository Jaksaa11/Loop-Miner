using UnityEngine;

public class Blocks : MonoBehaviour
{
    [SerializeField] private int startingHealth;
    [SerializeField] private int goldWorth;
    public int currentHealth { get; private set; }
    private void Awake()
    {
        currentHealth = startingHealth;
    }
    public void TakeDamage(int _damage)
    {
        currentHealth = currentHealth - _damage;
        if (currentHealth <= 0)
        {
            GameObject.Destroy(gameObject);
        }
    }
}
