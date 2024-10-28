using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitMainMenu : MonoBehaviour
{
    public void QuitToMainMenu()
    {
        // Carrega a MainScene
        SceneManager.LoadScene("MainMenu");
    }
}
