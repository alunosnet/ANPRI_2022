using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractDestroi : MonoBehaviour,IInteract
{
    public void Action()
    {
        Destroy(this.gameObject);
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
