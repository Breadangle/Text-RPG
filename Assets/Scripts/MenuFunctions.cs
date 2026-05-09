using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuFunctions : MonoBehaviour
{

    public void OnStartButton()
    {
        SceneManager.LoadScene("AutoMapTest");
    }

    public void OnQuitButton()
    {
        Application.Quit();
    }

}
