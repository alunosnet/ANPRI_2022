using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorInventario : MonoBehaviour
{
    [SerializeField] GameObject PanelInventario;
    [SerializeField] Image[] ImagensInventario;
    [SerializeField] List<ItemInventario> ListaItems;
    [SerializeField] List<ItemInventario> ListaAcoes;

    // Start is called before the first frame update
    void Start()
    {
        ImagensInventario = Utils.GetComponentsInChildWithoutRoot<Image>(PanelInventario);
        ListaItems = new List<ItemInventario>();
        ListaAcoes = new List<ItemInventario>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<ItemInventario>() && other.gameObject.activeInHierarchy)
            AdicionarAoInventario(other.gameObject);
    }

    private void AdicionarAoInventario(GameObject gameObject)
    {
        ItemInventario novo = gameObject.GetComponent<ItemInventario>();
        var som = gameObject.GetComponent<AudioSource>();
        if (som != null && som.clip!=null)
        {
            var audioSourcePlayer = transform.GetComponent<AudioSource>();
            audioSourcePlayer.clip=som.clip;
            audioSourcePlayer.Play();
        }
        AdicionarItem(novo);
        Destroy(gameObject);
    }

    public void AdicionarItem(ItemInventario novo)
    {
        if (novo.Visivel)
        {
            if (TemItem(novo.Nome) == false)
            {
                ListaItems.Add(novo);
            }
            else
            {
                AtualizarQuantidade(novo);
            }
        }
        else
        {
            ListaAcoes.Add(novo);
        }
    }

    private void AtualizarQuantidade(ItemInventario novo)
    {
        for (int i = 0; i < ListaItems.Count; i++)
        {
            if (ListaItems[i].Nome == novo.Nome)
            {
                ListaItems[i].Quantidade += novo.Quantidade;
                break;
            }
        }
    }

    public bool TemItem(string nome)
    {
        for (int i = 0; i < ListaItems.Count; i++)
        {
            if (ListaItems[i].Nome == nome) return true;
        }
        return false;
    }
    public bool TemAcao(string nome)
    {
        for (int i = 0; i < ListaAcoes.Count; i++)
        {
            if (ListaAcoes[i].Nome == nome) return true;
        }
        return false;
    }
    public void GastaItem(string nome,int quantidade = 1)
    {
        for (int i = 0; i < ListaItems.Count; i++)
        {
            ItemInventario atual = ListaItems[i];
            if (atual.Nome == nome)
            {
                atual.Quantidade -= quantidade;
                if (atual.Quantidade <= 0)
                    ListaItems.RemoveAt(i);
                else
                    ListaItems[i]=atual;
                break;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Inventario"))
        {
            PanelInventario.SetActive(!PanelInventario.activeInHierarchy);
            if (PanelInventario.activeInHierarchy)
            {
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.None;
                MostrarInventario();
            }
            else
            {
                Time.timeScale = 1;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }

    private void MostrarInventario()
    {
        //limpar imagens inventario
        for (int i = 0; i < ImagensInventario.Length; i++)
        {
            if (ImagensInventario[i] != null)
            {
                ImagensInventario[i].sprite = null;
                ImagensInventario[i].color = new Color(ImagensInventario[i].color.r,
                                                    ImagensInventario[i].color.g,
                                                    ImagensInventario[i].color.b);
                ImagensInventario[i].type = Image.Type.Sliced;
                ImagensInventario[i].GetComponentInChildren<Text>().text = "";
            }
        }
        //mostrar inventario
        for (int i = 0; i < ListaItems.Count; i++)
        {
            if (ImagensInventario[i] != null)
            {
                Rect rect = new Rect(0, 0, ListaItems[i].Imagem.width, ListaItems[i].Imagem.height);
                ImagensInventario[i].sprite = Sprite.Create(ListaItems[i].Imagem,rect,new Vector2(0,0));
                ImagensInventario[i].color = new Color(ImagensInventario[i].color.r,
                                                    ImagensInventario[i].color.g,
                                                    ImagensInventario[i].color.b,1);
                ImagensInventario[i].GetComponentInChildren<Text>().text = ListaItems[i].Quantidade.ToString();
            }
        }
    }
}
