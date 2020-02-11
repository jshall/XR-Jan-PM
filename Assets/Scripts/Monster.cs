using System.Linq;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public Transform Target;
    public float Speed = 1f;

    private Animation anim;
    private bool dead = false;

    void Start()
    {
        anim = GetComponent<Animation>();
    }

    void Update()
    {
        if (dead) return;

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
            anim.CrossFade("Attack");
            if (target.tag == "Food")
                Destroy(target.gameObject, 0.5f);
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
