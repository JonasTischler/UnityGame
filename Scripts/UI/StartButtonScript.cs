using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Certifique-se de incluir isso

public class StartButtonScript : MonoBehaviour
{
    public Button startButton; // A referência ao botão

    private void Start()
    {
        if (startButton != null)
        {
            startButton.onClick.AddListener(StartGame); // Adiciona o listener ao botão
        }
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level_01"); // Troca para a cena Level_01
    }
}
