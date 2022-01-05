using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombaExplosiva : MonoBehaviour
{
    [SerializeField] float RaioExplosao = 10f;
    [SerializeField] float ForcaExplosao = 10f;
    [SerializeField] int DanoExplosao = 50;
    [SerializeField] float IntervaloExplode = 2;
    [SerializeField] AudioSource audioSource;
    [SerializeField] GameObject efeitoExplosao;

    public void Explode()
    {
        Vector3 posicao = transform.position;
        Collider[] colliders = Physics.OverlapSphere(posicao, RaioExplosao);
        foreach(Collider obj in colliders)
        {
            if (obj is CharacterController) continue;
            
            Rigidbody rb=obj.GetComponent<Rigidbody>();
            if (rb != null)
                rb.AddExplosionForce(ForcaExplosao, posicao, RaioExplosao, 3);

            Vida vida = obj.GetComponent<Vida>();
            if (vida != null)
                vida.TiraVida(DanoExplosao);
        }
        audioSource.Play();
        if (efeitoExplosao != null)
        {
            var efeito = Instantiate(efeitoExplosao, transform.position, Quaternion.identity);
            Destroy(efeito, 4);
        }
        float duracao = audioSource.clip.length;
        Destroy(this.gameObject,duracao);
        //desativar o renderer
        transform.GetComponent<Renderer>().enabled = false;
        //desativar a luz
        transform.GetComponentInChildren<Light>().enabled = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        audioSource= GetComponent<AudioSource>();
        Invoke("Explode", IntervaloExplode);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
