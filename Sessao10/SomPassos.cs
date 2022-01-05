using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SomPassos : MonoBehaviour
{
    [SerializeField] AudioClip[] sons;
    [SerializeField] int index = 0;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource= GetComponent<AudioSource>();
    }
    public void TocarSom()
    {
        audioSource.clip= sons[index];
        audioSource.Play();
        index++;
        if (index > sons.Length - 1) index = 0;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
