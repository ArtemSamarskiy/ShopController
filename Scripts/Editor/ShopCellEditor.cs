using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ShopCell))]
public class ShopCellEditor : Editor
{
    public override void OnInspectorGUI()
    {
        ShopCell shopCell = (ShopCell) target;
        base.OnInspectorGUI();
        if (!shopCell.DataItem)
            EditorGUILayout.HelpBox("Предмет не найден! Настраиваеться автоматически", MessageType.Info);
        if(!shopCell.Background || !shopCell.Description || !shopCell.Icon || !shopCell.Title || !shopCell.EventTrigger)
            EditorGUILayout.HelpBox("Скрипт не работает! Не настроен", MessageType.Error);
    }
}
