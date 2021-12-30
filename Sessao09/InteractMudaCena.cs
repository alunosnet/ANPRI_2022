using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractMudaCena : MonoBehaviour, IInteract
{
    [SerializeField] string ItemNecessario = "";
    ControladorInventario controladorInventario;

    public void Action()
    {
        if (ItemNecessario != "")
        {
            if (controladorInventario.TemItem(ItemNecessario) == false)
            {
                SistemaMensagens.instance.ShowMessage($"Falta o item {ItemNecessario}");
                return;
            }
        }
        MudarCena();
    }

    private void MudarCena()
    {
        //final
        if (SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings - 1)
        {
            SistemaMensagens.instance.ShowMessage("Parabéns terminaste o jogo!");
            Invoke("MudaParaCenaPrincipal", 2);
        }
        else
        {
            SistemaMensagens.instance.ShowMessage("Vais para outra ilha!");
            Invoke("MudaParaProximaCena", 2);
        }
    }
    public void MudaParaCenaPrincipal()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }
    public void MudaParaProximaCena()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    // Start is called before the first frame update
    void Start()
    {
        controladorInventario=FindObjectOfType<ControladorInventario>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
