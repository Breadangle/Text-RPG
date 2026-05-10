using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuFunctions : MonoBehaviour
{
    public TextMeshProUGUI textMeshProUGUI;
    public void OnStartButton()
    {
        SceneManager.LoadScene("AutoMapTest");
    }

    public void OnQuitButton()
    {
        Application.Quit();
    }

    public void OnHelpButton()
    {
        if(textMeshProUGUI.enabled == true)
        {
            textMeshProUGUI.enabled = false;
        }
        else if (textMeshProUGUI.enabled == false)
        {
            textMeshProUGUI.enabled = true;
        }
    }

}
