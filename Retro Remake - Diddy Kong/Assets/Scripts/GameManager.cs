using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public int level;
    public int lives;
    public int score;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        NewGame();
    }

    private void NewGame()
    {
        lives = 3;
        score = 0;
        level = 3;

        LoadLevel(1);
    }
    private void LoadLevel(int level)
    {
        this.level = level;

        Camera camera = Camera.main;

        if (camera != null){
            camera.cullingMask = 0;
        }

        Invoke(nameof(LoadScene), 1f);
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(level);
    }

    public void LevelComplete() //I think the bug is here...
    {
        score += 1000;

        if (score > PlayerPrefs.GetInt("HighScore")) {
            PlayerPrefs.SetInt("HighScore", score);
        }

        int nextlevel = level + 1;

        if (nextlevel == 2)
        {
            nextlevel = 3;
        }

        if (nextlevel < SceneManager.sceneCountInBuildSettings)
        {
            LoadLevel(nextlevel);
        } else
        {
            LoadLevel(2);
            level = 2;
        }
    }



   public void LevelFailed()
   {
       lives--;

        if (lives <= 0)
        {
            LoadLevel(0);
        }
        else
        {
             LoadLevel(level);
        }
    }

}
