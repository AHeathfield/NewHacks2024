using UnityEngine;

public class ChoicePiece : MonoBehaviour
{
    public Animator animator;

    //animator = GetComponent<Animator>();
    public void PlayAnimate()
    {
        animator.SetTrigger("PlayTrigger");
    }

    public void PiecesAnimate()
    {
        animator.SetTrigger("PieceTrigger");
    }

}
