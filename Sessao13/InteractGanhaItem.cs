using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractGanhaItem : MonoBehaviour,IInteract
{
    [SerializeField] string ItemNecessario = "";
    [SerializeField] string NomeItemNovo = "";
    ControladorInventario controladorInventario;
    AudioSource som;
    public void Action()
    {
        if (controladorInventario.TemAcao(NomeItemNovo))
        {
            SistemaMensagens.instance.ShowMessage("Já executou esta tarefa.");
            return;
        }
        if(ItemNecessario=="" || (ItemNecessario!="" && controladorInventario.TemItem(ItemNecessario))){
            ItemInventario novo = new ItemInventario();
            novo.Nome= NomeItemNovo;
            novo.Visivel = false;
            controladorInventario.AdicionarItem(novo);
            SistemaMensagens.instance.ShowMessage($"{NomeItemNovo} concluído com sucesso.");
            if(som!=null && som.clip != null)
            {
                som.Play();
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        controladorInventario=FindObjectOfType<ControladorInventario>();
        som=GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
