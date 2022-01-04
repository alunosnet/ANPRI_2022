using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveNPC : MonoBehaviour
{
    public enum NPCEstados { Idle=0, Patrulha=1, Atacar=2, Morto=3}
    public NPCEstados Estado= NPCEstados.Idle;
    [SerializeField] public Transform[] Pontos;
    [SerializeField] int ProximoPonto = 0;
    [SerializeField] float DistanciaMinima = 1;
    [SerializeField] float Velocidade=3;
    [SerializeField] bool Inimigo = true;
    [SerializeField] Transform Olhos;
    [SerializeField] bool VePlayer = false;
    [SerializeField] float DistanciaVe = 50;
    [SerializeField] float DistanciaAtaque = 2;
    TiraVida tiravida;
    Vida vida;
    Animator animator;
    GameObject player;
    NavMeshAgent agente;
    // Start is called before the first frame update
    void Start()
    {
        tiravida = GetComponent<TiraVida>();
        vida=GetComponent<Vida>();
        if(vida==null)
            Debug.Log("Este npc " + gameObject.name + " não tem o componente vida");
        animator= GetComponent<Animator>();
        player = FindObjectOfType<MoverPlayer>().gameObject;
        agente= transform.GetComponent<NavMeshAgent>();
        if (agente != null)
        {
            agente.speed = Velocidade;
            GetComponent<Rigidbody>().isKinematic= true; 
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (vida != null && vida.GetVida() <= 0)
        {
            if (Estado != NPCEstados.Morto)
            {
                animator.SetTrigger("morre");
                Estado= NPCEstados.Morto;
            }
            return;
        }
        if (player == null) return;

        if (Inimigo)
        {
            VePlayer = Utils.CanYouSeeThis(Olhos, player.transform, null, 120, DistanciaVe);
            if(agente!=null && VePlayer)
            {
                agente.isStopped = false;
                agente.SetDestination(player.transform.position);
                Estado = NPCEstados.Atacar;
                if (animator != null)
                    animator.SetFloat("velocidade", agente.velocity.magnitude);
            }
            else
            {
                if (agente == null)
                {
                    Estado = NPCEstados.Patrulha;

                }
                else
                {
                    if (Vector3.Distance(transform.position, agente.destination) < DistanciaMinima)
                    {
                        Estado = NPCEstados.Patrulha;
                        agente.isStopped = true;
                    }
                }
            }
        }
        if (Estado == NPCEstados.Idle)
        {
            animator.SetFloat("velocidade", 0);
            return;
        }
        
        if(Estado==NPCEstados.Patrulha && Pontos.Length>0)
            Patrulhar();

        if (Estado == NPCEstados.Atacar && Inimigo)
            Atacar();
    }

    private void Atacar()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < DistanciaAtaque)
        {
            agente.isStopped = true;
            if (animator != null)
                animator.SetTrigger("atacar");
            tiravida.ExecutaColisao(player);
        }
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
        if (agente == null)
        {
            //rodar
            Vector3 direcao = Pontos[ProximoPonto].position - transform.position;
            Quaternion rotacao = Quaternion.LookRotation(direcao, Vector3.up);
            transform.rotation = rotacao;
            //mover
            transform.Translate(Vector3.forward * Velocidade * Time.deltaTime);
        }
        else
        {
            agente.isStopped = false;
            agente.SetDestination(Pontos[ProximoPonto].position);
            if(animator!=null)
                animator.SetFloat("velocidade", agente.velocity.magnitude);
        }
    }
}
