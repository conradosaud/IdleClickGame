using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Touch : MonoBehaviour, IPointerClickHandler
{

    private void Start()
    {
        AcionaClicador();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        GameManager.AddDinheiro( 1 * GameManager.multiplicadores );
    }

    void AcionaClicador()
    {
        GameManager.AddDinheiro( GameManager.clicadores );
        Invoke("AcionaClicador", 2);
    }

}
