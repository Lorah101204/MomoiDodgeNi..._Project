using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string sceneName;
    public GameObject setting;
    bool active;
    public void LoadScene() {
        SceneManager.LoadSceneAsync(sceneName);
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void VolSet() {
        if (active == false) {
            setting.transform.gameObject.SetActive(true);
            active = true;
        } else {
            setting.transform.gameObject.SetActive(false);
            active = false;
        }
    }
}

