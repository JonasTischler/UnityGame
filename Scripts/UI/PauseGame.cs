using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public GameObject pauseMenu; // O objeto do menu de pausa

    private void Start()
    {
        // Desativa o menu de pausa no início do jogo
        HidePauseMenu();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // Verifica se a tecla Esc foi pressionada
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        if (Time.timeScale == 1) // Se o jogo está ativo
        {
            Time.timeScale = 0; // Pausa o jogo
            ShowPauseMenu(); // Mostra o menu de pausa
        }
        else
        {
            Time.timeScale = 1; // Retorna o jogo ao ativo
            HidePauseMenu(); // Esconde o menu de pausa
        }
    }

    private void ShowPauseMenu()
    {
        pauseMenu.SetActive(true); // Ativa o menu de pausa
    }

    private void HidePauseMenu()
    {
        pauseMenu.SetActive(false); // Desativa o menu de pausa
    }
}
