using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    [Header("НАСТРОЙКА")]
    [SerializeField, Tooltip("Игровые деньги")] private float _money;

    [Header("ОСТАЛЬНОЕ")] 
    [SerializeField, Tooltip("Ссылка на ячейку")] private ShopCell _shopCell;
    [SerializeField] private Transform _conteiner;

    [Header("ПРЕДМЕТЫ")] 
    [SerializeField] private List<DataItemShop> _items = new List<DataItemShop>();

    private void Start()
    {
        if(!_conteiner) return;
        foreach (var item in _items)
        {
            ShopCell newCell = Instantiate(_shopCell, _conteiner);
            newCell.ShopController = this;
            newCell.DataItem = item;
            newCell.Init(this);
        }
    }

    #region Buy

    public bool Buy(DataItemShop dataItemShop)
    {
        if (!HasMoney(dataItemShop.Price)) return false;
        ChangeMoney(GetMoney()-dataItemShop.Price);
        return true;
    }

    #endregion

    #region Money

    public void ChangeMoney(float target_money) => _money = target_money;
    public float GetMoney() => _money;
    public bool HasMoney(float money) => GetMoney() >= money;

    #endregion
}
