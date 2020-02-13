using System.Linq;
using UnityEngine;
using UnityEngineInternal;

public class Monster : MonoBehaviour
{
    public Transform Target;
    public float Speed = 1f;

    private Animator anim;

    private bool Running
    {
        get => anim.GetBool("Moving");
        set
        {
            anim.SetBool("Moving", value);
             if (value) Attacking = false;
       }
    }

    public bool Attacking
    {
        get => anim.GetBool("Attacking");
        set
        {
            anim.SetBool("Attacking", value);
               if (value) Running = false;
     }
    }

    public bool Dead
    {
        get => anim.GetBool("Dead");
        set
        {
            anim.SetBool("Dead",value);
            if (value) Running = Attacking = false;
        }
    }

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Dead) return;

        // look for food
        var target = Target;
        var closest = Vector3.Distance(transform.position, target.position);
        foreach (var obj in from o in Physics.OverlapSphere(transform.position, 30)
                            where o.tag == "Food"
                            select o.transform)
        {
            var d = Vector3.Distance(transform.position, obj.position);
            if (closest < d) continue;
            target = obj;
            closest = d;
        }

        transform.LookAt(target);
        if (Vector3.Distance(transform.position, target.position) < 1.6)
        {
            Attacking = true;
            if (target.tag == "Food")
                Destroy(target.gameObject, 0.5f);
            else
                Player.Attack(1 * Time.deltaTime);
        }
        else
        {
            Running = true;
            transform.Translate(Vector3.forward * Time.deltaTime * Speed);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!Dead && collision.impulse.magnitude > 15)
        {
            var collider = GetComponent<SphereCollider>();
            if (collider != null)
            {
                collider.center = new Vector3(0, 1.4f, 0);
                collider.radius = 1.5f;
            }
            Dead = true;
        }
    }
}
