using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] float Distancia = 3;
    [SerializeField] LayerMask Layers;
    Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        camera = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            Vector3 origem =camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.5f)); //transform.position;
            RaycastHit hit;
            if(Physics.Raycast(origem, camera.transform.forward,out hit, Distancia, Layers))
            {
                //Debug.Log("Interact");
                var objeto = hit.collider.GetComponent<IInteract>();
                if (objeto != null)
                    objeto.Action();
            }
        }
    }
}
