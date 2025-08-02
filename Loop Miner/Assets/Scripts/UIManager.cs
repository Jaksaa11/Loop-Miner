using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [SerializeField] private TextMeshProUGUI coinsText;
    [SerializeField] private TextMeshProUGUI timer;
    [SerializeField] private GameObject shopUI;
    [SerializeField] private GameObject pauseMenu;

    private void Awake()
    {
        instance = this;
    }
    private void FixedUpdate()
    {
        timer.text = GameManager.instance.LoopLeft();
     
    }
    private void Update()
    {
        if (pauseMenu.activeInHierarchy || shopUI.activeInHierarchy)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
    public void ChangeCoinsText()
    {
        coinsText.text= GameManager.instance.goldCoins.ToString();
    }

    public void ShopButton()
    {
        shopUI.SetActive(!shopUI.activeInHierarchy);
    
    }
    public void PauseButton()
    {
        pauseMenu.SetActive(!pauseMenu.activeInHierarchy);
        
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("_MainMenu");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
