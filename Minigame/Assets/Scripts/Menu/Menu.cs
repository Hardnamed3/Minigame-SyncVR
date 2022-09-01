using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void StartGame()
    {
        Debug.Log("Start");
        ClearSpawners();
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        ClearSpawners();
    }

    public void Instructions()
    {
        Debug.Log("quit");
        Application.Quit();
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
        GameObject[] traps = GameObject.FindGameObjectsWithTag("Trap");
        foreach (var item in traps)
        {
            Destroy(item.gameObject);
        }
    }
}
