using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] float Distancia = 3;
    [SerializeField] LayerMask Layers;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            Vector3 origem = transform.position;
            RaycastHit hit;
            if(Physics.Raycast(origem,transform.forward,out hit, Distancia, Layers))
            {
                Debug.Log("Interact");
                var objeto = hit.collider.GetComponent<IInteract>();
                if (objeto != null)
                    objeto.Action();
            }
        }
    }
}
