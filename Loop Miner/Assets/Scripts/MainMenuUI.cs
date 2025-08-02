using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private GameObject htpUI;

    public void StartGame()
    {
        SceneManager.LoadScene("Mining");
    }

    public void HTP()
    {
        htpUI.SetActive(!htpUI.activeInHierarchy);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
