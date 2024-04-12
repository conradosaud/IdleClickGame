using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
///     Administra e contabiliza os toques na tela realizado pelo jogador.
///     Também é o responsável pela contagem de clicadores automáticos do jogador.
/// </summary>
public class Touch : MonoBehaviour, IPointerClickHandler
{

    private void Start()
    {
        // Ao iníciar a classe/jogo, inicia a função de clicadores automáticos
        AcionaClicador();
    }

    // Esta função é implementada automaticamente pelo IPointerClickHandler
    // Ela é chamada quando um click é dado no objeto que está este script
    // Para isso funcionar, o objeto deve ter um BoxCollider e a câmera deve ter o componente PhyscsRayCast
    public void OnPointerClick(PointerEventData eventData)
    {
        // Ao receber o click, adiciona 1 de dinheiro * o número de multiplicadores comprados
        GameManager.AddDinheiro( 1 * GameManager.multiplicadores );
    }

    void AcionaClicador()
    {
        // Aumenta o dinheiro de acordo com o número de clicadores comprados
        GameManager.AddDinheiro( GameManager.clicadores );
        // Faz a função se chamar, iniciando um loop, porém com um delay de 2 segundos
        Invoke("AcionaClicador", 2);
    }



}
