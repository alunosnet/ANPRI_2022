using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Gerir o estado do GameObject
/// Destroi o GameObject quando vida<=0
/// </summary>
public class Vida : MonoBehaviour
{
    [SerializeField] int vida = 100;
    AudioSource audioSource;
    [SerializeField] AudioClip SomPerderVida;
    [SerializeField] AudioClip SomGanharVida;
    [SerializeField] AudioClip SomMorrer;
    [SerializeField] float segundosParaDesaparecer = 0;
    [SerializeField] Text txtVidaPlayer;
    //TODO: Animator; 

    void AtualizarUI()
    {
        if (txtVidaPlayer != null)
            txtVidaPlayer.text = vida.ToString();
    }
    public int GetVida()
    {
        return vida;
    }
    public void TiraVida(int valor)
    {
        vida -= valor;
        AtualizarUI();
        if (vida <= 0)
        {
            //morreu
            vida = 0;
            Destroy(this.gameObject.transform.root.gameObject,segundosParaDesaparecer);
            //TODO: animação
            if(audioSource!=null && SomMorrer!=null)
            {
                audioSource.clip = SomMorrer;
                audioSource.Play();
            }
            return;
        }
        if(audioSource!=null && SomPerderVida != null)
        {
            audioSource.clip = SomPerderVida;
            audioSource.Play();
        }
    }
    public void GanhaVida(int valor)
    {
        vida += valor;
        if (vida > 100)
            vida = 100;
        AtualizarUI();
        if(audioSource!=null && SomGanharVida!=null){
            audioSource.clip=SomGanharVida;
            audioSource.Play();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        //TODO: animator
        audioSource = GetComponent<AudioSource>();
        AtualizarUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
