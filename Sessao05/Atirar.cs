using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atirar : MonoBehaviour
{
    [SerializeField] Transform PontoAtirar;
    [SerializeField] GameObject Modelo;
    [SerializeField] float ForcaAtirar = 5;
    [SerializeField] float TempoVidaObjeto = 3;

    // Start is called before the first frame update
    void Start()
    {
        if (PontoAtirar == null) PontoAtirar = this.transform;
        if (Modelo == null)
            Debug.Log("Falta o modelo do objeto a atirar");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            AtirarObjeto();
    }

    private void AtirarObjeto()
    {
        var objeto=Instantiate(Modelo, PontoAtirar.position, Quaternion.identity);
        objeto.GetComponent<Rigidbody>().AddForce(transform.forward * ForcaAtirar);
        Destroy(objeto,TempoVidaObjeto);
    }
}
