using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawner : MonoBehaviour
{
    [SerializeField] float Intervalo = 5;
    [SerializeField] GameObject Modelo;
    [SerializeField] int MaxNPCs = 5;
    [SerializeField] Transform[] Pontos;
    float NextSpawn = 0;
    // Start is called before the first frame update
    void Start()
    {
        NextSpawn = Intervalo;
    }

    // Update is called once per frame
    void Update()
    {
        NextSpawn -= Time.deltaTime;
        if (NextSpawn <= 0)
        {
            NextSpawn = Intervalo + Random.Range(0, 10);
            if (GameObject.FindObjectsOfType<MoveNPC>().Length >= MaxNPCs) return;
            Vector3 posicao = new Vector3(transform.position.x + Random.Range(-2, 2),
                                        transform.position.y,
                                        transform.position.z + Random.Range(-2, 2));
            var objeto=Instantiate(Modelo, posicao, Quaternion.identity);
            objeto.GetComponent<MoveNPC>().Pontos = Pontos;
            objeto.GetComponent<MoveNPC>().Estado = MoveNPC.NPCEstados.Patrulha;
        }
    }
}
