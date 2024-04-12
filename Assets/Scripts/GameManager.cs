using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
///     Gerencia todos os registros do jogo, como a quantidade de dinheiro, clicadores e multiplicadores
/// </summary>
public class GameManager : MonoBehaviour
{
    // Dinheiro
    public static int dinheiro = 0;
    static TextMeshProUGUI textoDinheiro;

    // Clicadores
    public static int clicadores = 0;
    public static int custoClicador = 25;

    // Multiplicadores
    public static int multiplicadores = 1;
    public static int custoMultiplicador = 90;

    // Está sendo usado Awake invés do Start porque a função AddDinheiro é estática e depende que o
    // texto do dinheiro exista para funcionar. Então deve ser iniciado com certeza antes de todos
    private void Awake()
    {

        CarregarJogo();

        // Pega o texto de dinheiro que está na tela
        textoDinheiro = GameObject.Find("Canvas").transform.Find("Dinheiro").GetComponent<TextMeshProUGUI>();
    
        // Atualiza o custo dos itens com base na quantidade comprada deles
        if( ExisteSave() )
        {
            custoClicador = clicadores * (int)Math.Floor(custoClicador * 1.25f);
            custoMultiplicador = multiplicadores * (int)Math.Floor(custoMultiplicador * 1.25f);
        }

        AutoSave();

    }

    private void OnApplicationQuit()
    {
        //SalvarJogo();
    }

    // A variável de dinheiro poderia ser alterada diretamente, porém ao usar esta função,
    // o texto do Canvas já é atualizado ao mesmo tempo
    public static void AddDinheiro(int valor)
    {
        GameManager.dinheiro += valor;
        textoDinheiro.text = "$ " + GameManager.dinheiro.ToString();
    }

    // ---------------------------------

    public static void SalvarJogo()
    {

        PlayerPrefs.SetInt("dinheiro", dinheiro);
        PlayerPrefs.SetInt("clicadores", clicadores);
        PlayerPrefs.SetInt("multiplicadores", multiplicadores);
        PlayerPrefs.Save();
        Debug.Log("Jogo salvo com sucesso!");

    }

    public void CarregarJogo()
    {

        if (ExisteSave() == false)
        {
            return;
        }

        dinheiro = PlayerPrefs.GetInt("dinheiro");
        clicadores = PlayerPrefs.GetInt("clicadores");
        multiplicadores = PlayerPrefs.GetInt("multiplicadores");

    }

    // Função com retorno
    bool ExisteSave()
    {
        if( PlayerPrefs.HasKey("dinheiro") == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void AutoSave()
    {
        SalvarJogo();
        Invoke("AutoSave", 5);
    }

}
