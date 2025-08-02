using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimeShopItem : MonoBehaviour
{
    [Header("Item Settings")]
    [SerializeField] private string itemName;
    [SerializeField] public int price;
    [SerializeField] public int TimeBonus;
    [SerializeField] private Button buyButton;
    public bool bought;
    public bool marked;
    [Header("ItemUI")]
    [SerializeField] private TextMeshProUGUI itemNameUI;
    [SerializeField] private TextMeshProUGUI priceUI;

    private void Awake()
    {
        itemNameUI.text = itemName;
        priceUI.text = price.ToString();
        if (buyButton != null)
            buyButton.onClick.AddListener(Buy);
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
                buyButton.onClick.AddListener(Buy);
            }
        
    }
    private void Buy()
    {
        ShopManager.instance.PurchaseTime(this);
    }

    private void Equip()
    {
        ShopManager.instance.EquipTime(this);
    }
}
