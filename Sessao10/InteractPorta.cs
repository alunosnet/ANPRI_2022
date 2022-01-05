using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractPorta : MonoBehaviour, IInteract
{
    [SerializeField] bool Estado = true;    //true=>fechada; false=>aberta
    [SerializeField] string NomeItemNecessario = "";
    [SerializeField] string NomeAnimacaoFalso = "fecha";
    [SerializeField] string NomeAnimacaoVerdadeiro = "abre";
    Animator animator;
    ControladorInventario controladorInventario;

    public void Action()
    {
        //testar se é necessário
        if (NomeItemNecessario != "")
        {
            if(controladorInventario!=null && controladorInventario.TemItem(NomeItemNecessario) == false)
            {
                SistemaMensagens.instance.ShowMessage($"Falta o item {NomeItemNecessario}");
                return;
            }
        }
        if (Estado)
        {
            animator.SetTrigger(NomeAnimacaoVerdadeiro);
        }
        else
        {
            animator.SetTrigger(NomeAnimacaoFalso);
        }
        Estado = !Estado;
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = transform.root.GetComponent<Animator>();
        controladorInventario = FindObjectOfType<ControladorInventario>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
