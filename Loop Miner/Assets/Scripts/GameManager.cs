using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField]private float loopInterval;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject gridTop;
    [SerializeField] private GameObject gridMiddle;
    [SerializeField] private GameObject gridEnd;
    public int goldCoins {  get; private set; } 
    private Vector3 initialPosition;
    private float loopTimer;

    private void Awake()
    {
        instance = this;
        initialPosition = player.transform.position;
        loopTimer = loopInterval;
    }

    private void FixedUpdate()
    {
        loopInterval -= Time.deltaTime;
        Debug.Log(loopInterval);
        if (loopInterval <= 0)
        {
            Loop();
            loopInterval = loopTimer;
        }
    }

    private void Loop()
    {
        player.transform.position = initialPosition;
        gridTop.GetComponent<GridGenerator>().ResetGrid();
        gridMiddle.GetComponent<GridGenerator>().ResetGrid();
        gridEnd.GetComponent<GridGenerator>().ResetGrid();

        
    }

    public void AddCoins(int amount)
    {
        goldCoins += amount;
    }
    public void RemoveCoins(int amount)
    {
        goldCoins -= amount;
    }
}
