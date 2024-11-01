using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour

{
    public void PlayGame()
    {
        StartCoroutine(PlayDelay());
    }

    public void PieceGallery()
    {
        StartCoroutine(PiecesDelay());
    }

    private IEnumerator PlayDelay()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private IEnumerator PiecesDelay()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
    public void QuitGame()
    {
        Application.Quit();
    }    

}
