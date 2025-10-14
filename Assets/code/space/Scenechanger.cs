using UnityEngine;
using UnityEngine.SceneManagement;
public class Scenechanger : MonoBehaviour
{
    public void ChangeScene()
    {
        SceneManager.LoadScene("Main");
    }
}
