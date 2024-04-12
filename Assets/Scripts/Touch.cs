using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
///     Administra e contabiliza os toques na tela realizado pelo jogador.
///     Tamb�m � o respons�vel pela contagem de clicadores autom�ticos do jogador.
/// </summary>
public class Touch : MonoBehaviour, IPointerClickHandler
{

    private void Start()
    {
        // Ao in�ciar a classe/jogo, inicia a fun��o de clicadores autom�ticos
        AcionaClicador();
    }

    // Esta fun��o � implementada automaticamente pelo IPointerClickHandler
    // Ela � chamada quando um click � dado no objeto que est� este script
    // Para isso funcionar, o objeto deve ter um BoxCollider e a c�mera deve ter o componente PhyscsRayCast
    public void OnPointerClick(PointerEventData eventData)
    {
        // Ao receber o click, adiciona 1 de dinheiro * o n�mero de multiplicadores comprados
        GameManager.AddDinheiro( 1 * GameManager.multiplicadores );
    }

    void AcionaClicador()
    {
        // Aumenta o dinheiro de acordo com o n�mero de clicadores comprados
        GameManager.AddDinheiro( GameManager.clicadores );
        // Faz a fun��o se chamar, iniciando um loop, por�m com um delay de 2 segundos
        Invoke("AcionaClicador", 2);
    }



}
