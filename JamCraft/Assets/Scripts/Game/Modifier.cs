using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Modifier : IEquatable<Modifier>
{
    public string ID;
    public string Source;
    public float Amount;
    public bool IsPercent;
    public int MaxStacks;
    public Modifier(string _id, string _source, float _amount, bool _isPercent, int _maxStacks)
    {
        ID = _id;
        Source = _source;
        Amount = _amount;
        IsPercent = _isPercent;
        MaxStacks = _maxStacks;
    }

    public bool Equals(Modifier other)
    {
        return (this.ID == other.ID);
    }
}
