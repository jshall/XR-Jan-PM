using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandAnimator : MonoBehaviour
{
    public KeyCode GrabKey = KeyCode.Mouse0;
    private Animator Anim;

    void Start()
    {
        Anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            Anim.SetBool("IsClosed", true);
        if (Input.GetKeyUp(KeyCode.Mouse0))
            Anim.SetBool("IsClosed", false);
    }
}
