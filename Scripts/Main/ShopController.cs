using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShopController : MonoBehaviour
{
    [Header("НАСТРОЙКА")] 
    [SerializeField, Tooltip("Игровые деньги")] private float _money;

    [Header("ОСТАЛЬНОЕ")] 
    [SerializeField, Tooltip("Ссылка на ячейку")] private ShopCell _shopCell;
    [SerializeField] private Transform _conteiner;

    [Header("ПРЕДМЕТЫ")] 
    [SerializeField] private List<DataItemShop> _items = new List<DataItemShop>();

    [HideInInspector] public UnityChangeMoney OnChangeMoney;
    
    private void Start()
    {
        if(!_conteiner) return;
        foreach (var item in _items)
        {
            ShopCell newCell = Instantiate(_shopCell, _conteiner);
            newCell.ShopController = this;
            newCell.DataItem = item;
            newCell.Init();
        }
    }

    #region Money

    public void ChangeMoney(float target_money)
    {
        OnChangeMoney.Invoke(GetMoney(), target_money);
        _money = target_money;
    }

    public float GetMoney() => _money;
    public bool HasMoney(float money) => GetMoney() >= money;

    #endregion
}

[Serializable]
public class UnityChangeMoney : UnityEvent<float, float> {}
