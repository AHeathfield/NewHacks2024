using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour

{
    //public Animator animator;


    void Start()
    {
        //animator = GetComponent<Animator>();
    }
    public void PlayGame()
    {
        //animator.SetTrigger("PlayTrigger");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame()
    {
        //animator.SetTrigger("QuitTrigger");
        Application.Quit();
    }

}
