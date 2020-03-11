using UnityEngine;
using UnityEngine.SceneManagement;

public class Reload : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F5) || Input.GetKeyDown(KeyCode.JoystickButton6))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
