using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveNPC : MonoBehaviour
{
    public enum NPCEstados { Idle=0, Patrulha=1, Atacar=2, Morto=3}
    public NPCEstados Estado= NPCEstados.Idle;
    [SerializeField] public Transform[] Pontos;
    [SerializeField] int ProximoPonto = 0;
    [SerializeField] float DistanciaMinima = 1;
    [SerializeField] float Velocidade=3;
    Vida vida;

    // Start is called before the first frame update
    void Start()
    {
        vida=GetComponent<Vida>();
        if(vida==null)
            Debug.Log("Este npc " + gameObject.name + " não tem o componente vida");
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((vida != null && vida.GetVida() <= 0) || Estado == NPCEstados.Morto) return;

        Patrulhar();
    }

    void Patrulhar()
    {
        //Debug.Log("Patrulhar");
        if (Vector3.Distance(transform.position, Pontos[ProximoPonto].position) < DistanciaMinima)
        {
            //passa para o próximo ponto
            ProximoPonto++;
            if (ProximoPonto > Pontos.Length - 1)
                ProximoPonto = 0;
        }
        //rodar
        Vector3 direcao=Pontos[ProximoPonto].position-transform.position;
        Quaternion rotacao = Quaternion.LookRotation(direcao, Vector3.up);
        transform.rotation = rotacao;
        //mover
        transform.Translate(Vector3.forward * Velocidade * Time.deltaTime);
    }
}
