using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        MenuDefinicoes.LoadSettings();
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Comecar()
    {
        SceneManager.LoadScene("Nivel1");
    }
    public void Continuar()
    {
        var indice = PlayerPrefs.GetInt("nivel", -1);
        if (indice == -1)
            Comecar();
        else
            SceneManager.LoadScene(indice);
    }
    public void Definicoes()
    {
        SceneManager.LoadScene("MenuDefinicoes");
    }
    public void Sair()
    {
        Application.Quit();
    }
}
