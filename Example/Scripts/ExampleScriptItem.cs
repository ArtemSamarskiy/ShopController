using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Example/Example script")]
public class ExampleScriptItem : ScriptItemShop
{
    [SerializeField] private bool _isDestroyObject;

    public override void Start() => Debug.Log("Script init");
    public override bool TryBuy()
    {
        Debug.Log("Try buy call");
        return base.TryBuy();
    }
    public override void OnBuy()
    {
        Debug.Log("Buy item");
    }

    public override bool TryDestroy()
    {
        Debug.Log("Cell destroy");
        return _isDestroyObject;
    }
}
