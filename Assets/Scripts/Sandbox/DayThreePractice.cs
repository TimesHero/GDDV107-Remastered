using UnityEngine;
using System.Collections.Generic;

public class DayThreePractice : MonoBehaviour
{

    [Header("If/Else Practice")]
    public bool hasDungeonKey = true;
    public int currentGold = 69;
    public bool weaponEquipped = true;
    public string weaponType = "Longsword";

    [Header("Switch, Case/Default Practice")]
    public string characterAction = "Attack";
    public int dice = 7;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        WeaponCheck();
        MoneyCount();
        PrintCharacterAction();
        RollDice();
        CharacterList();
    }

    public void WeaponCheck()
    {
        Debug.LogWarning("<color=cyan>-----[Weapon Check]-----</color>");
        if(weaponEquipped && hasDungeonKey)
        {
            if(weaponType == "Longsword")
            {
                Debug.Log($"Off with their heads!");
            }
            else
            {
                Debug.Log($"This weapon ain't gonna cut it, unfortunately.");
            }
        }
        else
        {
            Debug.Log($"Your fists are no match for their helmets.");
        }
    }

    public void MoneyCount()
    {
        Debug.LogWarning("<color=cyan>-----[Money Count]-----</color>");

        if(currentGold > 50)
        {
            Debug.Log($"You've got a lot of money!");
        }
        else if(currentGold < 15)
        {
            Debug.Log($"Not worth the energy to pick your pocket");
        }
        else
        {
            Debug.Log($"Not too much, not to little. Just the right amount.");
        }
    }

    public void PrintCharacterAction()
    {
        Debug.LogWarning("<color=cyan>-----[Character Action]-----</color>");

        switch(characterAction)
        {
            case "Heal":
                Debug.Log($"Used a potion.");
                break;
            case "Attack":
                Debug.Log($"To arms!");
                break;
            default:
                Debug.Log("Shields Up!");
                break;
        }
    }

    public void RollDice()
    {
        Debug.LogWarning("<color=cyan>-----[Roll Dice]-----</color>");

        switch(dice)
        {
            case 7:
            case 15:
                Debug.Log($"Damage done!");
                break;
            case 20:
                Debug.Log($"Critical Hit!");
                break;
            default:
                Debug.Log($"You miss.");
                break;
        }
    }

    public void CharacterList()
    {
        Debug.LogWarning("<color=cyan>-----[Party Members]-----</color>");
        List<string> PartyMembers = new List<string>()
        {
            "Astarion the High Elf Rogue",
            "Gale the Human Wizard",
            "Karlach the Zariel Tiefling Barbarian",
            "Lae'zel the Githyanki Fighter",
            "Shadowheart the High Half-Elf Cleric",
            "Wyll the Human Warlock"
        };

        Debug.LogFormat("Total Party Members: {0}", PartyMembers.Count);

        PartyMembers.Add("Halsin the Wood Elf Druid");
        Debug.Log($"{PartyMembers[6]} joined your party!");

        Debug.Log($"Total Members is now: {PartyMembers.Count}");
        string eatenMember = PartyMembers[0];
        PartyMembers.RemoveAt(0);
        Debug.Log($"{eatenMember} was eaten by a bear! Party Count is now {PartyMembers.Count}");
    }



}
