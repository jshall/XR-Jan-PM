using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour
{
    public GameObject Target;
    public float Speed = 1f;

    private Animation anim;
    private bool dead = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dead) return;

        transform.LookAt(Target.transform);
        if (Vector3.Distance(transform.position, Target.transform.position) < 1.6)
        {
            anim.CrossFade("Attack");
        }
        else
        {
            anim.CrossFade("Run");
            transform.Translate(Vector3.forward * Time.deltaTime * Speed);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!dead && collision.impulse.magnitude > 15)
        {
            var collider = GetComponent<SphereCollider>();
            if (collider != null)
            {
                collider.center = new Vector3(0, 1.4f, 0);
                collider.radius = 1.5f;
            }
            anim.CrossFade("Death");
            dead = true;
        }
    }
}
