using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerirArmas : MonoBehaviour
{
    [SerializeField]GameObject[] Armas;
    [SerializeField] int ArmaSelecionada = 0;

    // Start is called before the first frame update
    void Start()
    {
        AtualizarArmas();
    }

    private void AtualizarArmas()
    {
        for (int i = 0; i < Armas.Length; i++)
        {
            Armas[i].SetActive(false);
        }
        Armas[ArmaSelecionada].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        float i = Input.mouseScrollDelta.y;
        if (i > 0)
        {
            ArmaSelecionada++;
            if (ArmaSelecionada > Armas.Length - 1) ArmaSelecionada = 0;
            AtualizarArmas();
        }
        if (i < 0)
        {
            ArmaSelecionada--;
            if (ArmaSelecionada < 0) ArmaSelecionada = Armas.Length - 1;
            AtualizarArmas();
        }
    }
}
