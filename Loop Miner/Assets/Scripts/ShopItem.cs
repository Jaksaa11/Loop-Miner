using TMPro;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    public static ShopItem instance;
    [Header("Item Settings")]
    [SerializeField] private string itemName;
    [SerializeField] public int price;
    [SerializeField] public int miningBonus;
    [SerializeField] private Button buyButton;
    public bool bought;
    public bool marked;
    [Header("ItemUI")]
    [SerializeField] private TextMeshProUGUI itemNameUI;
    [SerializeField] private TextMeshProUGUI priceUI;

    private void Awake()
    {
        instance = this;
        itemNameUI.text = itemName;
        priceUI.text = price.ToString();
        if (buyButton != null)
            buyButton.onClick.AddListener(BuyItem);
    }
    private void Update()
    {
        
            if (bought)
            {
                if (marked == true)
                {
                    buyButton.GetComponentInChildren<TextMeshProUGUI>().text = "Equipped";
                    buyButton.interactable = false;
                }
                else
                {
                    buyButton.GetComponentInChildren<TextMeshProUGUI>().text = "Equip";
                    buyButton.interactable = true;
                    buyButton.onClick.RemoveAllListeners();
                    buyButton.onClick.AddListener(Equip);
                }
            }
            else
            {
                buyButton.GetComponentInChildren<TextMeshProUGUI>().text = "Buy";
                buyButton.onClick.RemoveAllListeners();
                buyButton.onClick.AddListener(BuyItem);
            }
        
    }
    public void BuyItem()
    {
        ShopManager.instance.PurchaseItem(this);

    }
    public void Equip()
    {
        ShopManager.instance.EquipItem(this);
    }
}
