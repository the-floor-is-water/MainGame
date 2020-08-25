using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface TFIWItem
{
    String Name { get; }
    Sprite Image { get; }
    int Category { get; }

    void OnPickUp();
    //void OnDrop();
}

public class TFIWItemEventArgs : EventArgs
{
    public TFIWItem Item;

    public TFIWItemEventArgs(TFIWItem item)
    {
        Item = item;
    }

}
