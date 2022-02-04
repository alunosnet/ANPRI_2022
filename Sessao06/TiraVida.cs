using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiraVida : MonoBehaviour
{
    [SerializeField] int Valor = 10;
    [SerializeField] float IntervaloTempo = 2;
    float IntervaloAtual = 0;
    [SerializeField] bool DestroiComColisao = false;

    private void OnTriggerEnter(Collider other)
    {
        ExecutaColisao(other.gameObject);
    }
   
    private void OnTriggerStay(Collider other)
    {
        ExecutaColisao(other.gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        ExecutaColisao(collision.gameObject);
    }
    
    private void OnCollisionStay(Collision collision)
    {
        ExecutaColisao(collision.gameObject);
    }
    public void ExecutaColisao(GameObject other)
    {
        if (IntervaloAtual > 0) return;
        var vida = other.GetComponent<Vida>();
        if (vida != null)
        {
            vida.TiraVida(Valor);
            IntervaloAtual = IntervaloTempo;
            if (DestroiComColisao)
                Destroy(this.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IntervaloAtual > 0) IntervaloAtual -= Time.deltaTime;
    }
    
}
