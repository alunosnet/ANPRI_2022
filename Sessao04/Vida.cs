using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour
{
    [SerializeField] int vida = 100;
    [SerializeField] float segundosParaDesaparecer = 0;

    public int GetVida() { return vida; }
    public void TiraVida(int valor)
    {
        vida -= valor;
        if (vida <= 0)
            Destroy(this.gameObject, segundosParaDesaparecer);
    }
    public void GanhaVida(int valor)
    {
        vida += valor;
        if (vida > 100) vida = 100;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (vida <= 0)
            Destroy(this.gameObject, segundosParaDesaparecer);
    }
}
