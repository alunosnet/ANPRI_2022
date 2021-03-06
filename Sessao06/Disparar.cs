using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparar : MonoBehaviour
{
    [SerializeField] Camera MainCamera;
    [SerializeField] float Distancia = 50f;
    [SerializeField] int DanoTirar = 10;
    [SerializeField] float ForcaTiro = 50;
    [SerializeField] LayerMask Layers;
    //TODO: som

    // Start is called before the first frame update
    void Start()
    {
        if (MainCamera == null)
            MainCamera = FindObjectOfType<Camera>();
    }

    void SimulaTiro()
    {
        Vector3 origem = MainCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.5f));
        RaycastHit hit;
        if(Physics.Raycast(origem,MainCamera.transform.forward,out hit, Distancia,Layers))
        {
            Debug.Log(hit.collider.name);
            var vida = hit.collider.GetComponent<Vida>();
            if (vida != null)
                vida.TiraVida(DanoTirar);

            var rb = hit.collider.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector3 direcao = hit.collider.transform.position - transform.position;
                rb.AddForceAtPosition(direcao.normalized * ForcaTiro, hit.point);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            SimulaTiro();
        }
    }
}
