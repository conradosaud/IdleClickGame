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
        // Pega o texto de dinheiro que está na tela
        textoDinheiro = GameObject.Find("Canvas").transform.Find("Dinheiro").GetComponent<TextMeshProUGUI>();
        CarregarJogo();

        if (existeSave())
        {
            custoClicador = clicadores * (int)Math.Floor(GameManager.custoClicador * 1.25f);
            custoMultiplicador = multiplicadores * (int)Math.Floor(GameManager.custoMultiplicador * 1.25f);
        }

        AutoSave();
    }

    // A variável de dinheiro poderia ser alterada diretamente, porém ao usar esta função,
    // o texto do Canvas já é atualizado ao mesmo tempo
    public static void AddDinheiro(int valor)
    {
        GameManager.dinheiro += valor;
        textoDinheiro.text = "$ " + GameManager.dinheiro.ToString();
    }

    //----------------------------------------------------------------------------------------

    public static void SaveGame()
    {
        PlayerPrefs.SetInt("Dinheiro", dinheiro);
        PlayerPrefs.SetInt("Clickers", clicadores);
        PlayerPrefs.SetInt("mult", multiplicadores);
        PlayerPrefs.Save();

    }

    public void CarregarJogo()
    {
        if (existeSave() == false)
        {
            return;
        }
        dinheiro = PlayerPrefs.GetInt("Dinheiro");
        clicadores = PlayerPrefs.GetInt("Clickers");
        multiplicadores = PlayerPrefs.GetInt("mult");
    }

    bool existeSave()
    {
        if (PlayerPrefs.HasKey("Dinheiro") == true)
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
        SaveGame();
        Invoke("AutoSave", 5);
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }
}
