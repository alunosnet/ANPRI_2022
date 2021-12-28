using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombaExplosiva : MonoBehaviour
{
    [SerializeField] float RaioExplosao = 10f;
    [SerializeField] float ForcaExplosao = 10f;
    [SerializeField] int DanoExplosao = 50;
    [SerializeField] float IntervaloExplode = 2;
    //TODO: Efeito e som

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
        Destroy(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Explode", IntervaloExplode);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
