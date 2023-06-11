using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject buttonPausa;
    [SerializeField]
    private GameObject menuOptions;
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void ResetLevel()
    {
        Time.timeScale = 1f;
        // Obtener el nobmre de la escena actual
        string currentSceneName = SceneManager.GetActiveScene().name;

        // Cargar la escena actual
        SceneManager.LoadScene(currentSceneName);
    }
    public void NextLevel()
    {
        Time.timeScale = 1f;
        // Obtener el índice de la escena actual
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Cargar la siguiente escena sumando 1 al índice actual
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
    public void Stop()
    {
        // Detener el juego
        Time.timeScale = 0f;
        buttonPausa.SetActive(false);
        menuOptions.SetActive(true);
    }
    public void Continue()
    {
        Time.timeScale = 1f;
        buttonPausa.SetActive(true);
        menuOptions.SetActive(false);
    }
    public void Options()
    {
        Time.timeScale = 1f;
        buttonPausa.SetActive(true);
        menuOptions.SetActive(false);
    }
    public void Exit()
    {
        SceneManager.LoadScene("Menu");
    }
    public void ExitGame()
    {
        // Salir de la aplicación
        Application.Quit();
    }

}
