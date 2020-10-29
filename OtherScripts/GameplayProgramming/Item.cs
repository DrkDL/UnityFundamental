using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject // allows to create object from this scriptable object, just a blueprint that holds data
{
    new public string name = "item";
    public Sprite icon = null;

    public virtual void Use () // using virtual because its a base class and can be overriden by other script (inheritance)
    {

    }

}
