using UnityEngine;

[CreateAssetMenu(fileName = "New Item Data", menuName = "Item Data")]
public class ItemData : ScriptableObject
{
    [SerializeField] Texture itemTexture;
    [SerializeField] float price;
    [SerializeField] float energyConversation;

    public Texture ItemTexture
    {
        get { return itemTexture; }
    }

    public float Price
    {
        get { return price; }
    }

    public float EnergyConversation
    {
        get { return energyConversation; }
    }
}
