using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item/New Item")]
public class DataItemShop : ScriptableObject
{
    [Header("GUI")] 
    [Tooltip("Название")] public string Title;
    [Tooltip("Описание")] public string Description;
    [Tooltip("Иконка")] public Sprite Icon;
    
    [Header("НАСТРОЙКА")]
    [Tooltip("Цена предмета"), Min(0)] public float Price;
    [Tooltip("Скрипт предмета")] public ScriptItemShop ScriptItem;
}
