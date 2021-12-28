using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vida : MonoBehaviour
{
    [SerializeField] int vida = 100;
    [SerializeField] float segundosParaDesaparecer = 0;
    [SerializeField] Text txtVidaPlayer;
    void AtualizarUI()
    {
        if (txtVidaPlayer != null)
            txtVidaPlayer.text = vida.ToString();
    }

    public int GetVida() { return vida; }
    public void TiraVida(int valor)
    {
        vida -= valor;
        AtualizarUI();
        if (vida <= 0)
            Destroy(this.gameObject, segundosParaDesaparecer);
    }
    public void GanhaVida(int valor)
    {
        vida += valor;
        AtualizarUI();
        if (vida > 100) vida = 100;
    }
    // Start is called before the first frame update
    void Start()
    {
        AtualizarUI();
    }

    // Update is called once per frame
    void Update()
    {
        if (vida <= 0)
            Destroy(this.gameObject, segundosParaDesaparecer);
    }
}
