using NaughtyAttributes;
using System;
using UnityEngine;

[Flags] public enum ItemVariant
{
None = 0,
Normal = 1,
Tool = 2,
}

[CreateAssetMenu(menuName = "Game/Item")]
public class ItemObject : ScriptableObject
{
    [Header("Item Type")]
    public ItemVariant ItemType;
    [Header("Main")]
    public string Name;
    [TextArea(5, 10)]public string Description;
    public string Tooltip;
    [ShowAssetPreview]
    public Sprite DefaultSprite;
    public bool CanStack;
    [ShowIf("CanStack")] public int MaxStack;

}
