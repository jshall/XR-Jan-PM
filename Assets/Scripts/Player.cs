using System.Threading;
using UnityEngine.SceneManagement;

public static class Player
{
    public static float HitPoints { get; private set; }
    public static float MaxHitPoints { get; private set; } = 100;

    private static Mutex lck = new Mutex();

    static Player()
    {
        HitPoints = MaxHitPoints;
    }

    public static void Hit(float damage)
    {
        lck.WaitOne();
        HitPoints -= damage;

        if (HitPoints <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public static void Reset()
        => HitPoints = MaxHitPoints;
}
