using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static bool bigBulletBool = false;
    public static bool redBulletBool = false;
    public static bool explosiveBulletBool = false;
    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void BigBullet()
    {
        bigBulletBool = true;

    }
    public void RedBullet()
    {
        redBulletBool = true;

    }
    public void ExplosiveBullet()
    {
        explosiveBulletBool = true;
    }
    public void ResetBulletSettings()
    {
        bigBulletBool = false;
        redBulletBool = false;
        explosiveBulletBool = false;
    }
}
