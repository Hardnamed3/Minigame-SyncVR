using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Caught : MonoBehaviour
{
    public static bool GameOver { get; set; }
    [SerializeField] GameObject CaughtMenuUI;

    void Update() 
    { 
        if (GameOver)
        {
            Time.timeScale = 0f;
            CaughtMenuUI.SetActive(true);
            if (Score.MostTime < Timer.TimePassed)
            {
                Score.MostTime = Timer.TimePassed;
            }
            if (Score.MostEnemies < Score.EnemyScore)
            {
                Score.MostEnemies = Score.EnemyScore;
            }
        }
    }
    public void RestartGame()
    {
        Debug.Log("Restart");
        Time.timeScale = 1f;
        CaughtMenuUI.SetActive(false);
        ClearSpawners();
        Timer.TimePassed = 0;
        Score.EnemyScore = 0;
        GameOver = false;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void MainMenu()
    {
        Debug.Log("main menu");
        ClearSpawners();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void QuitGame()
    {
        Debug.Log("quit");
        Application.Quit();
    }
    private void ClearSpawners()
    {
        GameObject[] copies = GameObject.FindGameObjectsWithTag("copy");
        foreach (var item in copies)
        {
            Destroy(item.gameObject);
        }
        ChaserSpawner.nextActionTime = 0f;
        GameObject[] traps = GameObject.FindGameObjectsWithTag("Trap");
        foreach (var item in traps)
        {
            Destroy(item.gameObject);
        }
        Trapspawner.nextActionTime = 0f;
    }
}
