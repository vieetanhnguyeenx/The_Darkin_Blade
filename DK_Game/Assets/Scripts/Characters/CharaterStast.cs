using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

public class CharaterStast
{
    public float BaseValue;

    public float Value
    {
        get
        {
            if (isDirty || BaseValue != lastBaseValue)
            {
                lastBaseValue = BaseValue;
                _value = CaculateFinalValue();
                isDirty = false;
            }

            return _value;
        }
    }

    private readonly List<StatModifier> statModifiers;
    public readonly ReadOnlyCollection<StatModifier> StatModifiers;
    private float lastBaseValue = float.MinValue;

    public CharaterStast(float baseValue)
    {
        BaseValue = baseValue;
        statModifiers = new List<StatModifier>();
        StatModifiers = statModifiers.AsReadOnly();
    }

    private bool isDirty = true;
    private float _value;

    public bool RemoveAllModifiersFromSource(object source)
    {
        bool isRemoved = false;
        for (int i = statModifiers.Count - 1; i >= 0; i--)
        {
            if (statModifiers[i].Source == source)
            {
                isDirty = true;
                isRemoved = true;
                statModifiers.RemoveAt(i);
            }
        }
        return isRemoved;
    }

    private int CompareModifierOrder(StatModifier a, StatModifier b)
    {
        if (a.Order < b.Order)
            return -1;
        else if (a.Order > b.Order)
            return 1;
        return 0;
    }
    public void AddModifier(StatModifier mod)
    {
        isDirty = true;
        statModifiers.Add(mod);
        statModifiers.Sort(CompareModifierOrder);
    }

    public bool RemoveModifier(StatModifier mod)
    {
        if (statModifiers.Remove(mod))
        {
            isDirty = true;
            return true;
        }
        return false;
    }

    private float CaculateFinalValue()
    {
        float finalValue = BaseValue;
        float sumPercentAdd = 0;

        for (int i = 0; i < statModifiers.Count; i++)
        {
            StatModifier mod = statModifiers[i];
            if (mod.Type == StatModType.Flat)
            {
                finalValue += mod.Value;
            }
            else if (mod.Type == StatModType.PercentAdd)
            {
                sumPercentAdd += mod.Value;
                if (i + 1 >= statModifiers.Count || statModifiers[i + 1].Type != StatModType.PercentAdd)
                {
                    finalValue *= 1 + sumPercentAdd;
                    sumPercentAdd = 0;
                }
            }
            else if (mod.Type == StatModType.PercentMult)
            {
                finalValue *= 1 + mod.Value;
            }

        }

        return (float)Math.Round(finalValue, 4);
    }
}
