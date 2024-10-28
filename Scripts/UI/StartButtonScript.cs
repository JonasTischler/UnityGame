using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Certifique-se de incluir isso

public class StartButtonScript : MonoBehaviour
{
    public Button startButton; // A refer�ncia ao bot�o

    private void Start()
    {
        if (startButton != null)
        {
            startButton.onClick.AddListener(StartGame); // Adiciona o listener ao bot�o
        }
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level_01"); // Troca para a cena Level_01
    }
}
