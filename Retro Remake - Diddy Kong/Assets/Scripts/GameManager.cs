using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int lives;
    private int score;

    private void Start()
    {
        NewGame();
    }

    private void NewGame()
    {
        lives = 3;
        score = 0;

        //load loading screen
    }

    public void LevelComplete()
    {
        score += 1000;

        //load next level...
    }


   public void LevelFailed()
   {
       lives--;

        if (lives <= 0)
        {
            NewGame();
        }
        else
        {
             //reload current level
        }
    }

}
