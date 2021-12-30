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
        string[] elementos = resolucao.Split('x');
        int largura = int.Parse(elementos[0]);
        int altura=int.Parse(elementos[1]);
        Screen.SetResolution(largura, altura, tgFullscreen.isOn);
        //TODO: guardar as definições
    }
    public void AlterouQualidade(int i)
    {
        QualitySettings.SetQualityLevel(i, true);
        //TODO: guardar as definições
    }
    public void AlterouFullscreen()
    {
        Screen.fullScreen = tgFullscreen.isOn;
        //TODO: guardar as definições
    }
    public void Voltar()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
