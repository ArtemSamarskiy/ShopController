using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptItemShop : ScriptableObject
{
    [HideInInspector] public ShopController ShopController;
    [HideInInspector] public DataItemShop DataItemShop;
    [HideInInspector] public ShopCell ShopCell;
    
    // ================================================================= Main
    public virtual void Start() { }
    public virtual void Update() { }
    // =================================================================
    
    // ================================================================= Other
    public virtual bool TryDestroy() => true; // Вызываеться когда нужно удалить ячейку (true - можно удалить false - нельзя)
    public virtual void OnMouseEnter() { }
    public virtual void OnMouseExit() { }
    public virtual void OnChangeMoney(float old_money, float new_money) { } // Вызываеться когда меняеться кол-во денег
    // =================================================================
    
    // ================================================================= Buy
    public virtual bool TryBuy() => true; // Вызываеться когда игрок пытаеться купить предмет (true - можно купить false - нельзя)
    public virtual void OnBuy() { } // Вызываеться когда купили данный предмет
    // =================================================================
}
