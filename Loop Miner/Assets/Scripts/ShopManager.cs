using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Video;

public class ShopManager : MonoBehaviour
{
    public static ShopManager instance;
    [SerializeField] private GameObject[] shopItems;
    [SerializeField] private GameObject[] TimeItems;
    
    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void PurchaseItem(ShopItem item)
    {
       
            if (GameManager.instance.goldCoins >= item.price)
            {
                item.bought = true;
                for (int i = 0; i < shopItems.Length; i++)
                {
                    shopItems[i].GetComponent<ShopItem>().marked = false;
                }
                item.marked = true;
                GameManager.instance.RemoveCoins(item.price);
                UIManager.instance.ChangeCoinsText();
                Mining.instance.ChangeDamage(item.miningBonus);
                
            }
            else
            {
                Debug.Log("Not enought coins");
            }
        
    }

    public void EquipItem(ShopItem item)
    {
        
            for (int i = 0; i < shopItems.Length; i++)
            {
                shopItems[i].GetComponent<ShopItem>().marked = false;
            }
            item.marked = true;
            Mining.instance.ChangeDamage(item.miningBonus);
        
    }

    public void PurchaseTime(TimeShopItem item)
    {
        
            if (GameManager.instance.goldCoins >= item.price)
            {
                item.bought = true;
                for (int i = 0; i < TimeItems.Length; i++)
                {
                    TimeItems[i].GetComponent<TimeShopItem>().marked = false;
                }
                item.marked = true;
                GameManager.instance.RemoveCoins(item.price);
                UIManager.instance.ChangeCoinsText();
                GameManager.instance.ChangeInterval(item.TimeBonus);
            }
            else
            {
                Debug.Log("Not enought coins");
            }
        
    }

    public void EquipTime(TimeShopItem item)
    {
        
            for (int i = 0; i < TimeItems.Length; i++)
            {
                TimeItems[i].GetComponent<TimeShopItem>().marked = false;
            }
            item.marked = true;
            GameManager.instance.ChangeInterval(item.TimeBonus);
        
    }
}
