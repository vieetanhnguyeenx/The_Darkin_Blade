using Assets.Scripts.Characters;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] public CharaterStast MaxHealth;
    [SerializeField] public CharaterStast Damage;
    [SerializeField] public CharaterStast Armor;
    [SerializeField] public CharaterStast AttackSpeed;
    [SerializeField] public CharaterStast LifeSteal;

    private void Awake()
    {
        MaxHealth = new CharaterStast(10000);
        Damage = new CharaterStast(70);
        Armor = new CharaterStast(30);
        AttackSpeed = new CharaterStast(0.7f);
        LifeSteal = new CharaterStast(0.5f);

    }

}
