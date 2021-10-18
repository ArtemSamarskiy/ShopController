using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptItemShop : ScriptableObject
{
    [HideInInspector] public ShopController ShopController;
    [HideInInspector] public DataItemShop DataItemShop;
    [HideInInspector] public ShopCell ShopCell;
    
    // ================================================================= Main
    public virtual void Start() {}
    public virtual void Update() {}
    // =================================================================
    
    // ================================================================= Other
    public virtual bool TryDestroy() => true; // Вызываеться когда нужно удалить ячейку
    // =================================================================
    
    // ================================================================= Buy
    public virtual bool TryBuy() => true; // Вызываеться когда игрок пытаеться купить предмет (true - можно купить false - нельзя купить)
    public virtual void OnBuy() {} // Вызываеться когда купили данный предмет
    // =================================================================
}
