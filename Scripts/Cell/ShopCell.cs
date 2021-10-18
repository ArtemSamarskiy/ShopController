using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopCell : MonoBehaviour
{
    [Header("ВЫВОД")] 
    [SerializeField] private string _outputTitle = "{0} <size=27>{1}$</size=27>";
    [SerializeField] private string _outputDescription = "{0}";
    
    [Header("ССЫЛКИ")]
    [Tooltip("Кнопка покупки")] public Button BuyButton;
    [Tooltip("TextMeshPro для вывода названия")] public TextMeshProUGUI Title;
    [Tooltip("TextMeshPro для вывода описания")] public TextMeshProUGUI Description;
    [Tooltip("Задний фон")] public Image Background;
    [Tooltip("Иконка предмета")] public Image Icon;

    [HideInInspector] public DataItemShop DataItem;
    [HideInInspector] public ShopController ShopController;
    [HideInInspector] public ScriptItemShop CurrentScript;

    public void Init()
    {
        if(!DataItem.ScriptItem || !DataItem || !ShopController) Destroy(gameObject);

        Title.text = string.Format(_outputTitle, DataItem.Title, DataItem.Price);
        Description.text = string.Format(_outputDescription, DataItem.Description, DataItem.Price);
        Icon.sprite = DataItem.Icon;
        BuyButton.onClick.AddListener(Buy);
        InitScript(DataItem, ShopController);
    }
    
    private void Buy()
    {
        if(!CurrentScript.TryBuy()) return;
        if(ShopController.HasMoney(DataItem.Price))
            ShopController.ChangeMoney(ShopController.GetMoney()-DataItem.Price);
        else return;
        CurrentScript.OnBuy();
        if(CurrentScript.TryDestroy())
            Destroy(gameObject);
    }
    
    private void InitScript(DataItemShop dataItemShop, ShopController shopController)
    {
        if(CurrentScript) Destroy(CurrentScript);
        if(!dataItemShop.ScriptItem) return;
        CurrentScript = Instantiate(dataItemShop.ScriptItem, transform);
        CurrentScript.DataItemShop = dataItemShop;
        CurrentScript.ShopController = shopController;
        CurrentScript.ShopCell = this;
        CurrentScript.Start();
        CurrentScript.OnChangeMoney(0, shopController.GetMoney());
        shopController.OnChangeMoney.AddListener(CurrentScript.OnChangeMoney);
    }

    private void Update() => CurrentScript.Update();
}
