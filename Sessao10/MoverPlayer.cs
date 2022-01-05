using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverPlayer : MonoBehaviour
{
    [SerializeField] float VelocidadeAndar = 5;
    [SerializeField] float VelocidadeRodar = 5;
    [SerializeField] float VelocidadeSalto = 5;
    CharacterController cc;
    CollisionFlags collisionFlags;
    Animator animator;
    [SerializeField]bool NoChao;
    [SerializeField]float TempoNoAr=0;
    Vector3 velocidade;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState= CursorLockMode.Locked;
        cc = GetComponent<CharacterController>();
        if (cc == null)
            Debug.Log("O player necessita de ter o Character Controller");
        animator= GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0) return;
        NoChao = cc.isGrounded;
        if(NoChao)
        {
            TempoNoAr = 0;
            if (velocidade.y < 0)
                velocidade.y = 0;
        }
        else
        {
            TempoNoAr += Time.deltaTime;
        }
        //Rodar
        //float rodar = Input.GetAxis("Horizontal");
        float rodar = Input.GetAxis("Mouse X");
        transform.Rotate(transform.up * rodar * VelocidadeRodar * Time.deltaTime);

        //andar
        float andar = Input.GetAxis("Vertical");
        
        //correr
        if(andar>=0)
            andar *= Input.GetButton("Run") ? 2 : 1;

        Vector3 movimento = transform.forward * andar * VelocidadeAndar * Time.deltaTime;
        collisionFlags= cc.Move(movimento);
        animator.SetFloat("velocidade", andar * (TempoNoAr < 0.5f ? 1 : 0));

        //saltar
        if(Input.GetButtonDown("Jump") && NoChao)
        {
            velocidade.y = Mathf.Sqrt(VelocidadeSalto * Physics.gravity.y);
            animator.SetTrigger("salta");
        }
        velocidade += Physics.gravity * Time.deltaTime;
        collisionFlags = cc.Move(velocidade * Time.deltaTime);
    }
}
