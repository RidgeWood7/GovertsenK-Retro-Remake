using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    private int level;
    private int lives;
    private int score;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        NewGame();
    }

    private void NewGame()
    {
        lives = 3;
        score = 0;
        level = 1;

        LoadLevel(2);
    }
    private void LoadLevel(int index)
    {
        level = index;

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

    public void LevelComplete()
    {
        score += 1000;

        int nextlevel = level + 1;

        if (nextlevel < SceneManager.sceneCountInBuildSettings)
        {
            LoadLevel(nextlevel);
        } else
        {
            LoadLevel(0);
            nextlevel = 0;
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
