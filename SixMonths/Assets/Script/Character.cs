using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour
{
    public Stats CharacterStats;

    public int StatPoints = 0;

    public int MaxHealth = 10;
    public int MaxMana = 10;
    public int Health = 10;
    public int Mana = 10;

	// Use this for initialization
	void Start()
    {
	    
	}
	
	// Update is called once per frame
	void Update()
    {
	
	}

    public void LevelUp()
    {
        StatPoints += 7;
        Health = MaxHealth;
        Mana = MaxMana;
    }

    public void UpdateStats(Stats NewStats)
    {
        CharacterStats = NewStats;

        Health = MaxHealth = CalculateMaxHeatlh(CharacterStats.Strength, CharacterStats.Dexterity);
        Mana = MaxMana = CalculateMaxMana(CharacterStats.Wisdom);
    }

    int CalculateMaxHeatlh(int Strength, int Dexterity)
    {
        int health = 0;

        health = (Strength * 10) + (Dexterity * 7);

        return health;
    }

    int CalculateMaxMana(int Wisdom)
    {
        int mana = 0;

        Wisdom = Mathf.Max(0, Wisdom);
        mana = (Wisdom * 12);
        mana += mana / Wisdom;

        return mana;
    }
}

public struct Stats
{
    public int Strength = 5;
    public int Dexterity = 5;
    public int Intelligence = 5;
    public int Wisdom = 5;
    public int MagicalDefense = 0;
    public int PhysicalDefense = 0;

    public static Stats operator +(Stats s1, Stats s2)
    {
        Stats newStats = s1;

        newStats.Strength = s1.Strength + s2.Strength;
        newStats.Dexterity = s1.Dexterity + s2.Dexterity;
        newStats.Intelligence = s1.Intelligence + s2.Intelligence;
        newStats.Wisdom = s1.Wisdom + s2.Wisdom;
        newStats.MagicalDefense = s1.MagicalDefense + s2.MagicalDefense;
        newStats.PhysicalDefense = s1.PhysicalDefense + s2.PhysicalDefense;

        return newStats;
    }
}