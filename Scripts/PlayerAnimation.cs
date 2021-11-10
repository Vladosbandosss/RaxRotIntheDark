using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    
    public void Walk(bool walk)
    {
        anim.SetBool("walk", walk);
    }

    public void Jump(bool jump)
    {
        anim.SetBool("jump", jump);
    }
}
