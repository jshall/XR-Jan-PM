using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject Bullet;
    public float Speed = 100;

    private const int limit = 5;
    private static int limiter = 0;
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) || Input.GetKey(KeyCode.Mouse1))
            if (limiter < limit)
                limiter++;
            else
            {
                limiter = 0;
                var multiplier = 1;
                var bullet = Instantiate(Bullet, transform.position, transform.rotation);
                if (Input.GetKey(KeyCode.Mouse1))
                {
                    multiplier = 50;
                    Destroy(bullet, 10);
                }
                else
                {
                    bullet.tag = "Food";
                    Destroy(bullet, 300);
                }
                bullet.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * Speed * multiplier);
            }
    }
}
