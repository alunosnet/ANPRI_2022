using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractLigarDesligar : MonoBehaviour, IInteract
{
    [SerializeField] Light luz;
    public void Action()
    {
        if (luz != null)
            luz.enabled = !luz.enabled;
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
