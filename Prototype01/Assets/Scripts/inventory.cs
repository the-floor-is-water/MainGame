using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventory : MonoBehaviour
{
    public TFIWItem firstItem;
    public TFIWItem secondItem;
    public TFIWItem extraItem;

    public event EventHandler<TFIWItemEventArgs> ItemAdded;

    public void AddItem(TFIWItem item)
    {
        Collider collider = (item as MonoBehaviour).GetComponent<Collider>();
        if(collider.enabled)
        {
            collider.enabled = false;
            if(item.Category == 1)
            {
                if (secondItem == null)
                    secondItem = item;
                else
                {
                    if(firstItem != null)
                    {
                        //TODO: firstItem.OnDrop(); - Item exchange funtionality
                    }
                    firstItem = item;
                }
                item.OnPickUp();
            }
            else if(item.Category == 2)
            {
                if (extraItem != null)
                {
                    //TODO: firstItem.OnDrop(); - Item exchange funtionality
                }
                extraItem = item;
                item.OnPickUp();
            }
            else { }

            if (ItemAdded != null)
                ItemAdded(this, new TFIWItemEventArgs(item));

        }
    }


}
