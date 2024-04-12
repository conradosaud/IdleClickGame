using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Melhorias : MonoBehaviour
{

    Transform canvasMelhorias;

    TextMeshProUGUI textoQuantidadeClicadores;
    TextMeshProUGUI textoValorClicadores;

    TextMeshProUGUI textoQuantidadeMultiplicador;
    TextMeshProUGUI textoValorMultiplicador;

    private void Start()
    {
        canvasMelhorias = GameObject.Find("Canvas").transform.Find("Melhorias").transform;
        
        textoQuantidadeClicadores = canvasMelhorias.Find("Clicadores").transform.Find("Quantidade").GetComponent<TextMeshProUGUI>();
        textoValorClicadores = canvasMelhorias.Find("Clicadores").transform.Find("Valor").GetComponent<TextMeshProUGUI>();

        textoQuantidadeMultiplicador = canvasMelhorias.Find("Multiplicadores").transform.Find("Quantidade").GetComponent<TextMeshProUGUI>();
        textoValorMultiplicador = canvasMelhorias.Find("Multiplicadores").transform.Find("Valor").GetComponent<TextMeshProUGUI>();

        textoQuantidadeClicadores.text = GameManager.clicadores.ToString();
        textoValorClicadores.text = GameManager.custoClicador.ToString();
        textoQuantidadeMultiplicador.text = GameManager.multiplicadores.ToString();
        textoValorMultiplicador.text = GameManager.custoMultiplicador.ToString();

    }

    public void ComprarClicador()
    {
        if( GameManager.dinheiro >= GameManager.custoClicador)
        {

            ToastNotification.Show("Compra realizada com sucesso!", "success");

            GameManager.AddDinheiro( - GameManager.custoClicador );

            GameManager.clicadores += 1;
            GameManager.custoClicador = (int)Math.Floor( GameManager.custoClicador * 1.25f );
            textoQuantidadeClicadores.text = GameManager.clicadores.ToString();
            textoValorClicadores.text = "$ "+GameManager.custoClicador.ToString();

        }
        else
        {
            ToastNotification.Show("Dinheiro insuficiente...", 1.5f, "error");
        }
    }

    public void ComprarMultiplicador()
    {
        if (GameManager.dinheiro >= GameManager.custoMultiplicador)
        {

            ToastNotification.Show("Compra realizada com sucesso!", "success");
            GameManager.AddDinheiro(-GameManager.custoMultiplicador);

            GameManager.multiplicadores += 1;
            GameManager.custoMultiplicador = (int)Math.Floor(GameManager.custoMultiplicador * 1.25f);
            textoQuantidadeMultiplicador.text = GameManager.multiplicadores.ToString();
            textoValorMultiplicador.text = "$ " + GameManager.custoMultiplicador.ToString();

        }
        else
        {
            ToastNotification.Show("Dinheiro insuficiente...", 1.5f, "error");
        }
    }

}
