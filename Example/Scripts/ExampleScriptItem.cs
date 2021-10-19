using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Example/Example script")]
public class ExampleScriptItem : ScriptItemShop
{
    [SerializeField] private Color _colorDefault = new Color(0.52f, 0.53f, 1f);
    [SerializeField] private Color _colorNotEnough = new Color(1f, 0.47f, 0.44f);
    [SerializeField] private Color _colorEnough = new Color(0.56f, 1f, 0.51f);

    private bool _isMouseEnter;
    private enum TypeUpdate
    {
        Update,
        Exit,
        Enter
    }

    public override void OnMouseEnter()
    {
        _isMouseEnter = true;
        UpdateColor(TypeUpdate.Enter, ShopController.GetMoney());
    }

    public override void OnMouseExit()
    {
        _isMouseEnter = false;
        UpdateColor(TypeUpdate.Exit);
    }

    public override void OnChangeMoney(float old_money, float new_money) => UpdateColor(TypeUpdate.Update, new_money);

    public override bool TryDestroy() => false;
    private void UpdateColor(TypeUpdate typeUpdate, float money = default)
    {
        Image background = ShopCell.Background;
        if(!background) return;
        if ((typeUpdate == TypeUpdate.Update || typeUpdate == TypeUpdate.Enter) && _isMouseEnter)
            background.color = money >= DataItemShop.Price ? _colorEnough : _colorNotEnough;
        else background.color = _colorDefault;
    }
}
