using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitScene : MonoBehaviour
{
    public void ExitLevel()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
