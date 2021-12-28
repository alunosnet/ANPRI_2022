using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiraVida : MonoBehaviour
{
    [SerializeField] int Valor = 10;

    private void OnTriggerEnter(Collider other)
    {
        var vida=other.GetComponent<Vida>();
        if (vida != null)
            vida.TiraVida(Valor);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
