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

    // Est� sendo usado Awake inv�s do Start porque a fun��o AddDinheiro � est�tica e depende que o
    // texto do dinheiro exista para funcionar. Ent�o deve ser iniciado com certeza antes de todos
    private void Awake()
    {
        CarregarJogo();
        // Pega o texto de dinheiro que est� na tela
        textoDinheiro = GameObject.Find("Canvas").transform.Find("Dinheiro").GetComponent<TextMeshProUGUI>();
        if (ExisteSave() == true)
        {
            custoClicador = clicadores * (int)Math.Floor(custoClicador * 1.25f);
            custoMultiplicador = multiplicadores * (int)Math.Floor(custoClicador * 1.25f);
            Debug.Log("fr");
        }
        AutoSave();
    }

    // A vari�vel de dinheiro poderia ser alterada diretamente, por�m ao usar esta fun��o,
    // o texto do Canvas j� � atualizado ao mesmo tempo
    public static void AddDinheiro(int valor)
    {
        GameManager.dinheiro += valor;
        textoDinheiro.text = "$ " + GameManager.dinheiro.ToString();

    }



    //-------------------
    public static void SalvarJogo()
    {
        PlayerPrefs.SetInt("dinheiro", dinheiro);
        // clicadores
        PlayerPrefs.SetInt("clivadores", clicadores);
        // multiplicadores
        PlayerPrefs.SetInt("multiplicadores", multiplicadores);
        PlayerPrefs.Save();
        Debug.Log("jojojoj");
    }

    public void CarregarJogo()
    {
        if(ExisteSave() == false)
        {
            return;
        }
        dinheiro = PlayerPrefs.GetInt("dinheiro");
        clicadores = PlayerPrefs.GetInt("clicadores");
        multiplicadores = PlayerPrefs.GetInt("multiplicadores");
    }

    static bool ExisteSave()
    {
        if(PlayerPrefs.HasKey("dinheiro") == true )
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
