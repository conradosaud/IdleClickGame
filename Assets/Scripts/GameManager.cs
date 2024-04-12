using System.Collections;
using System.Collections.Generic;
using System.IO;
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

        AutoSave();
    }

    // A variável de dinheiro poderia ser alterada diretamente, porém ao usar esta função,
    // o texto do Canvas já é atualizado ao mesmo tempo
    public static void AddDinheiro(int valor)
    {
        GameManager.dinheiro += valor;
        textoDinheiro.text = "$ " + GameManager.dinheiro.ToString();
    }

    // -----------------------------------

    public void SalvarJogo()
    {

        DadosJogo dj = new DadosJogo();
        dj.dinheiro = dinheiro;
        dj.clicadores = clicadores;
        dj.multiplicadores = multiplicadores;

        string json = JsonUtility.ToJson(dj);
        string nomeArquivo = "save_data.json";
        string pasta = Application.persistentDataPath;
        string caminho = pasta + Path.AltDirectorySeparatorChar + nomeArquivo;

        File.WriteAllText(caminho, json);

    }

    void AutoSave()
    {
        SalvarJogo();
        Invoke("AutoSave", 5);
    }


    void CarregarJogo()
    {
        string nomeArquivo = "save_data.json";
        string pasta = Application.persistentDataPath;
        string caminho = pasta + Path.AltDirectorySeparatorChar + nomeArquivo;

        string dados = null;
        if( File.Exists(caminho))
        {
            dados = File.ReadAllText(caminho);
        }

        DadosJogo dj = JsonUtility.FromJson<DadosJogo>(dados);

        dinheiro = dj.dinheiro;
        clicadores = dj.clicadores;
        multiplicadores = dj.multiplicadores;

        // PlayerPrefs.DeleteAll();
        // File.Delete(caminho);

    }

}

class DadosJogo
{
    public int dinheiro;
    public int clicadores;
    public int multiplicadores;
}