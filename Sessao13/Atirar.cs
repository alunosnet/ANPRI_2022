using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Atirar : MonoBehaviour
{
    [SerializeField] Transform PontoAtirar;
    [SerializeField] GameObject Modelo;
    [SerializeField] float ForcaAtirar = 5;
    [SerializeField] float TempoVidaObjeto = 3;
    [SerializeField] Image ImagemDaArmaSelecionada;
    [SerializeField] Sprite ImagemDestaArma;
    Animator animator;
    [SerializeField] float AtrasoAtirar = 0.7f;
    [SerializeField] string NomeItemNecessario = "";
    ControladorInventario controladorInventario;
    //Alterado em 07/03/2022 para evitar atirar várias pedras antes de concluir a animação
    [SerializeField] float IntervaloAtirar = 2;
    float IntervaloAtual = 0;
    // Start is called before the first frame update
    void Start()
    {
        controladorInventario = FindObjectOfType<ControladorInventario>();
        animator = transform.parent.GetComponent<Animator>();
        if (PontoAtirar == null) PontoAtirar = this.transform;
        if (Modelo == null)
            Debug.Log("Falta o modelo do objeto a atirar");
    }
    private void OnEnable()
    {
        if (ImagemDaArmaSelecionada != null && ImagemDestaArma != null)
            ImagemDaArmaSelecionada.sprite = ImagemDestaArma;
    }
    // Update is called once per frame
    void Update()
    {
        //Alterado em 07/03/2022 para evitar atirar várias pedras antes de concluir a animação
        if (IntervaloAtual > 0)
        {
            IntervaloAtual -= Time.deltaTime;
            return;
        }
        if (Input.GetButtonDown("Fire1") && Time.timeScale!=0)
        {
            if (NomeItemNecessario == "" || (NomeItemNecessario != "" && controladorInventario.TemItem(NomeItemNecessario)))
            {
                animator.SetTrigger("atira");
                Invoke("AtirarObjeto", AtrasoAtirar);
                //Alterado em 07/03/2022 para evitar atirar várias pedras antes de concluir a animação
                IntervaloAtual = IntervaloAtirar;
            }
            else
            {
                SistemaMensagens.instance.ShowMessage($"Necessita de {NomeItemNecessario}");
            }
        }
    }

    private void AtirarObjeto()
    {

        var objeto = Instantiate(Modelo, PontoAtirar.position, Quaternion.identity);
        objeto.GetComponent<Rigidbody>().AddForce(transform.forward * ForcaAtirar);
        Destroy(objeto, TempoVidaObjeto);
        if (NomeItemNecessario != "")
            controladorInventario.GastaItem(NomeItemNecessario);


    }
}
