using UnityEngine;

public class QuitButtonScript : MonoBehaviour
{
    // Este m�todo � chamado para sair do jogo
    public void Quit()
    {
        // Se estivermos no editor, apenas parar a execu��o
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // Sai do jogo quando estiver em execu��o
#endif
    }
}
