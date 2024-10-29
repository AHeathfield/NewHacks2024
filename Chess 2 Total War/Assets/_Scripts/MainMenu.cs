using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour

{
    public Animator animator;
    public void PlayGame()
    {
        animator.SetTrigger("PlayTrigger");
        //StartCoroutine(DelayFunction());
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        animator.SetTrigger("QuitTrigger");
        Application.Quit();
    }
}
