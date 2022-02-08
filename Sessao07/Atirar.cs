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
    // Start is called before the first frame update
    void Start()
    {
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
        if (Input.GetButtonDown("Fire1") && Time.timeScale!=0)
            AtirarObjeto();
    }

    private void AtirarObjeto()
    {
        var objeto=Instantiate(Modelo, PontoAtirar.position, Quaternion.identity);
        objeto.GetComponent<Rigidbody>().AddForce(transform.forward * ForcaAtirar);
        Destroy(objeto,TempoVidaObjeto);
    }
}
