using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [SerializeField] private TextMeshProUGUI coinsText;

    private void Awake()
    {
        instance = this;
    }
    public void ChangeCoinsText()
    {
        coinsText.text= GameManager.instance.goldCoins.ToString();
    }
}
