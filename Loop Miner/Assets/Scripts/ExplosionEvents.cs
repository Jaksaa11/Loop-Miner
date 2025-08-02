using UnityEngine;
using UnityEngine.SceneManagement;

public class ExplosionEvents : MonoBehaviour
{
    [SerializeField] private GameObject[] objects;
    [SerializeField] private Camera kamera;
    public void DestroyEverything()
    {
        for (int i = 0; i < objects.Length; i++)
        {
            GameObject.Destroy(objects[i]);
            kamera.backgroundColor = Color.black;
        }
    }

    public void TheEnd()
    {
        SceneManager.LoadScene("TheEnd");
    }
}
