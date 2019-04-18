using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    private void Start()
    {
        PlayerPrefs.SetInt("BloodSpawnChance", 0);
        PlayerPrefs.SetInt("PausePlayer", 0);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !pauseMenu.activeInHierarchy)
        {
            Time.timeScale = 0f;
            pauseMenu.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            PlayerPrefs.SetInt("PausePlayer", 1);
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && pauseMenu.activeInHierarchy)
        {
            Time.timeScale = 1f;
            pauseMenu.SetActive(false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            PlayerPrefs.SetInt("PausePlayer", 0);
        }
    }
    public void Resume()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        PlayerPrefs.SetInt("PausePlayer", 0);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
