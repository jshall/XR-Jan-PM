using UnityEngine;
using UnityEngine.SceneManagement;

public class Reload : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F5))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
