using UnityEngine;

public class QuitButtonScript : MonoBehaviour
{
    // Este método é chamado para sair do jogo
    public void Quit()
    {
        // Se estivermos no editor, apenas parar a execução
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // Sai do jogo quando estiver em execução
#endif
    }
}
