using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuDefinicoes : MonoBehaviour
{
    [SerializeField] Dropdown ddQualidade;
    [SerializeField] Dropdown ddResolucao;
    [SerializeField] Toggle tgFullscreen;

    public void AlterouResolucao(int i)
    {
        string resolucao = ddResolucao.options[i].text;
        AplicarResolucao(resolucao);

        PlayerPrefs.SetString("ScreenResolution", resolucao);
        PlayerPrefs.Save();
    }

    private static void AplicarResolucao(string resolucao)
    {
        string[] elementos = resolucao.Split('x');
        int largura = int.Parse(elementos[0]);
        int altura = int.Parse(elementos[1]);
        Screen.SetResolution(largura, altura, Screen.fullScreen);
    }

    public void AlterouQualidade(int i)
    {
        QualitySettings.SetQualityLevel(i, true);

        PlayerPrefs.SetInt("QualitySettings", i);
        PlayerPrefs.Save();
    }
    public void AlterouFullscreen()
    {
        Screen.fullScreen = tgFullscreen.isOn;

        PlayerPrefs.SetInt("FullScreen", Screen.fullScreen == true ? 1 : 0);
        PlayerPrefs.Save();
    }
    public static void LoadSettings()
    {
        //fullscreen
        Screen.fullScreen = PlayerPrefs.GetInt("FullScreen", 1) == 1 ? true : false;

        //resolução
        string resolucao = PlayerPrefs.GetString("ScreenResolution", "800X600");
        AplicarResolucao(resolucao);

        //qualidade
        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("QualitySettings", 3), true);
    }
    public void Voltar()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }
    // Start is called before the first frame update
    void Start()
    {
        //Preparar a UI
        tgFullscreen.isOn = PlayerPrefs.GetInt("FullScreen", 1) == 1 ? true : false;
        ddQualidade.value = PlayerPrefs.GetInt("QualitySettings", 3);

        string resolucao = PlayerPrefs.GetString("ScreenResolution", "800X600");
        for (int i = 0; i < ddResolucao.options.Count; i++)
        {
            if (ddResolucao.options[i].text == resolucao)
            {
                ddResolucao.value = i;
                break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
