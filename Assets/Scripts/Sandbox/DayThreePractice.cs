using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using NUnit.Framework;
using UnityEditor.ShaderGraph.Internal;

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

    [Header("List Things")]
    [SerializeField] List<string> PartyMembers = new List<string>();
    [SerializeField] List<string> WaitingCharacters = new List<string>();
    [SerializeField] int[] HighScores = new int[25];

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        WeaponCheck();
        MoneyCount();
        PrintCharacterAction();
        RollDice();
        CharacterList();
        ItemDictionary();
        PartyLoops();
        GridArray();
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
            case 7: //will fall through to the next with an assigned thing to do.
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

    public void CharacterList() //Played with adding and removing things from a list.
    {
        Debug.LogWarning("<color=cyan>-----[Party Members]-----</color>");
        PartyMembers.AddRange(new string[]
        {
            "Astarion the High Elf Rogue",
            "Gale the Human Wizard",
            "Karlach the Zariel Tiefling Barbarian",
            "Lae'zel the Githyanki Fighter",
            "Shadowheart the High Half-Elf Cleric",
            "Wyll the Human Warlock"
        });

        Debug.LogFormat("Total Party Members: {0}", PartyMembers.Count);

        PartyMembers.Add("Halsin the Wood Elf Druid");
        Debug.Log($"{PartyMembers[6]} joined your party!");

        Debug.Log($"Total Members is now: {PartyMembers.Count}");
        string eatenMember = PartyMembers[0];
        PartyMembers.RemoveAt(0);
        Debug.Log($"{eatenMember} was eaten by a bear! Party Count is now {PartyMembers.Count}");
    }

    public void ItemDictionary()
    {
        Debug.LogWarning("<color=cyan>-----[Player Inventory]-----</color>");
        Dictionary<string, int> ItemInventory = new Dictionary<string, int>()
        {
            { "Potion", 5},
            { "Antidote", 7},
            { "Cheese", 2}
        };

        Debug.Log($"{ItemInventory["Antidote"]}"); //So this will only print 7, the value beside the string "key"
    }

    public void PartyLoops()
    {
        string transitioningCharacter;
        WaitingCharacters.AddRange(new string[]
        {
            "Alfira the Tiefling Bard",
            "Minsc the Human Ranger/Hunter",
            "Minthara the Drow Paladin",
            "Scratch the Dog",
            "Sazza the Goblin Brawler"
        });
        Debug.LogWarning("<color=cyan>-----[Loops and Such]-----</color>");
        int totalCharacters = PartyMembers.Count;

        Debug.Log($"There are {totalCharacters} in your party right now.");
        for  (int i = 0; i < totalCharacters; i++)
        {
            Debug.Log($"Party member number{i+1}: {PartyMembers[i]}");
        }

        if (PartyMembers.Count < 10)
        {
            for (int i = WaitingCharacters.Count-1; i >= 0; i--)
            {
                if (PartyMembers.Count >= 10)
                {
                    Debug.Log("Your Party is now Full.");
                    break;
                }
                transitioningCharacter = WaitingCharacters[i];
                WaitingCharacters.RemoveAt(i);
                PartyMembers.Add(transitioningCharacter);
                Debug.Log($"{transitioningCharacter} has joined your party!");
            }
        }  
    }

    public void GridArray()
    {
        Debug.LogWarning("<color=cyan>-----[Grid Array Loopy Thing]-----</color>");
        int highestScore = int.MinValue;
        int lowestScore = int.MaxValue;
        int scoresAdded = 0;

        //Fill The arrray
        for(int i = 0; i < HighScores.Length; i++)
        {
            HighScores[i] = Random.Range(1,100);
            
            Debug.Log($"{HighScores[i]}");

            if(HighScores[i] >= highestScore)
            {
                highestScore = HighScores[i];
            }
            if(HighScores[i] <= lowestScore)
            {
                lowestScore = HighScores[i];
            }

            scoresAdded = scoresAdded + HighScores[i];

        }

        Debug.Log($"Highest Score = {highestScore}");
        Debug.Log($"Lowest Score = {lowestScore}");
        Debug.Log($"Added Scores = {scoresAdded}");

        string gridPrint = "";

        for(int i = 0; i < HighScores.Length; i++)
        {
            gridPrint = gridPrint + HighScores[i] + "\t";

            if ((i + 1) % 5 == 0)
            {
                gridPrint = gridPrint + "\n";
            }
        }

        Debug.Log($"{gridPrint}");


    }

}
