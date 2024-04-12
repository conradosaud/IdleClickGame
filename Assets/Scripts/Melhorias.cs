using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
///     Script responsável por administrar a compra das melhorias do jogo e atualizar os dados no Canvas.
/// </summary>
public class Melhorias : MonoBehaviour
{

    Transform canvasMelhorias;

    TextMeshProUGUI textoQuantidadeClicadores;
    TextMeshProUGUI textoValorClicadores;

    TextMeshProUGUI textoQuantidadeMultiplicador;
    TextMeshProUGUI textoValorMultiplicador;

    private void Start()
    {

        // Obtém todos os campos de texto do Canvas que serão utilizados neste script
        canvasMelhorias = GameObject.Find("Canvas").transform.Find("Melhorias").transform;
        
        textoQuantidadeClicadores = canvasMelhorias.Find("Clicadores").transform.Find("Quantidade").GetComponent<TextMeshProUGUI>();
        textoValorClicadores = canvasMelhorias.Find("Clicadores").transform.Find("Valor").GetComponent<TextMeshProUGUI>();

        textoQuantidadeMultiplicador = canvasMelhorias.Find("Multiplicadores").transform.Find("Quantidade").GetComponent<TextMeshProUGUI>();
        textoValorMultiplicador = canvasMelhorias.Find("Multiplicadores").transform.Find("Valor").GetComponent<TextMeshProUGUI>();

        // Inicia o jogo alterando os textos para os valores atuais do GameManager
        textoQuantidadeClicadores.text = GameManager.clicadores.ToString();
        textoValorClicadores.text = GameManager.custoClicador.ToString();
        textoQuantidadeMultiplicador.text = GameManager.multiplicadores.ToString();
        textoValorMultiplicador.text = GameManager.custoMultiplicador.ToString();

    }

    public void ComprarClicador()
    {
        // Verifica se tem dinheiro suficiente para a compra
        if( GameManager.dinheiro >= GameManager.custoClicador)
        {
            // Exibe uma mensage na tela usando um pacote muito bom chamado ToastNotificationMessage
            // Baixe ele na Unity Asset Store e faça uma avaliação de 5 estrelas, pq é mto bom msm sério
            ToastNotification.Show("Compra realizada com sucesso!", "success");

            // A função AddDinheiro faz uma soma. Se passar um valor negativo, ele faz uma subtração do valor
            GameManager.AddDinheiro( - GameManager.custoClicador );

            // Aumenta o número de clicadores
            GameManager.clicadores += 1;
            // Aumenta o custo em 25%
            GameManager.custoClicador = (int)Math.Floor( GameManager.custoClicador * 1.25f );
            // Exibe as alterações na tela do Canvas
            textoQuantidadeClicadores.text = GameManager.clicadores.ToString();
            textoValorClicadores.text = "$ "+GameManager.custoClicador.ToString();

        }
        else
        {
            // Se não houver dinheiro, apenas mostra uma mensagem
            ToastNotification.Show("Dinheiro insuficiente...", 1.5f, "error");
        }
    }

    // O multiplicador faz exatamente as mesmas coisas dos clicadores.
    // Porém usando o exemplo do "early return" para não precisar colocar tudo dentro do IF.
    public void ComprarMultiplicador()
    {
        // Faz a lógica contrária: invés de validar se tem dinheiro, verifica se NÃO TEM
        if (GameManager.dinheiro < GameManager.custoMultiplicador)
        {
            ToastNotification.Show("Dinheiro insuficiente...", 1.5f, "error");
            return; // Cancela toda a função e nada continua daqui pra baixo
        }

        // Se o código não foi retornado, então tudo aqui vai rodar...

        ToastNotification.Show("Compra realizada com sucesso!", "success");
        GameManager.AddDinheiro(-GameManager.custoMultiplicador);

        GameManager.multiplicadores += 1;
        GameManager.custoMultiplicador = (int)Math.Floor(GameManager.custoMultiplicador * 1.25f);
        textoQuantidadeMultiplicador.text = GameManager.multiplicadores.ToString();
        textoValorMultiplicador.text = "$ " + GameManager.custoMultiplicador.ToString();

    }

}
