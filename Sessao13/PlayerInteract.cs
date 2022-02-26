using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] float Distancia = 3;
    [SerializeField] LayerMask Layers;
    Camera _camera;
    CinemachineVirtualCamera _cinemachine;
    CinemachineTransposer _transposer;
    float _distanciaPlayer = 0;
    // Start is called before the first frame update
    void Start()
    {
        _camera = FindObjectOfType<Camera>();
        _cinemachine = FindObjectOfType<CinemachineVirtualCamera>();
        _transposer = _cinemachine.GetCinemachineComponent<CinemachineTransposer>();
        _distanciaPlayer = Mathf.Abs(_transposer.m_FollowOffset.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            Vector3 origem =_camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.5f)); //transform.position;
            RaycastHit hit;
            if(Physics.Raycast(origem, _camera.transform.forward,out hit, _distanciaPlayer+Distancia, Layers))
            {
                //Debug.Log("Interact");
                var objeto = hit.collider.GetComponent<IInteract>();
                if (objeto != null)
                    objeto.Action();
            }
        }
    }
}
