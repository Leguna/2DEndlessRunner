using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private static readonly int IsGround = Animator.StringToHash("isGround");
    private static readonly int IsRun = Animator.StringToHash("isRun");

    public void SetIsGround(bool value)
    {
        animator.SetBool(IsGround, value);
    }

    public void Running(bool value)
    {
        animator.SetBool(IsRun,value);
    }
}
