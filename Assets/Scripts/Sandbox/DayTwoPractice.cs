using UnityEngine;
using System;
using Unity.VisualScripting;


public class DayTwoPractice : MonoBehaviour
{
    [Header("Day 2 Practice")]
    //Textbook example showcasing how variables act as placeholders
    public int currentAge = 30;
    public int addedAge = 1;
    public bool knowWhatABooleanIs = true;
    public PostOffice poClass;
    public EnumPractice enumPractice;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ComputeAge(); //will print both Debug.Log() statements to the console
        PostageParse();
        PrintSomeEnums();
        LetsGetFancyWithABool();

        //Textbook Chapter 3 Stuff
        Debug.LogWarning("<color=cyan>-----[Character Generator]-----</color>");
        int characterLevel = 36;
        int nextSkillLevel = CharacterGenerator("Alexander", characterLevel);
        Debug.Log(nextSkillLevel);
        Debug.Log(CharacterGenerator("Rachel", characterLevel));
    }

    public int CharacterGenerator(string name, int level)
    {
        //Debug.LogWarning("<color=cyan>-----[Character Generator]-----</color>");
        //Debug.LogFormat("Character Name: {0} - Level: {1}", name, level );
        return level += 69;
    }

    public void ComputeAge() //went a little above and beyond here and made a method for currentAge practice
    {
        Debug.LogWarning("<color=yellow>-----[ComputeAge]-----</color>");
        Debug.Log($"Hard coded Values 30 + 1 = {30 + 1}"); //Hard coded example
        Debug.Log($"Added 'currentAge + 1' = {currentAge +1}"); //calls on the public variable that can be changed in the inspector
        Debug.Log($"Adding currentAge with addedAge variables gets you {currentAge + addedAge}"); //puts both int variables together
    }

    public void PostageParse() //pulls from the text book PostOffice Class created in chapter 2 of "Learning C#"
    {
        Debug.LogWarning("<color=yellow>-----[Post Office Things]-----</color>");
        poClass.DeliverMail();
        poClass.SendMail();
    }

    public void PrintSomeEnums()
    {
        Debug.LogWarning("<color=yellow>-----[eNum Practice]-----</color>");
        enumPractice.PrintTheBestEnum();
    }

    public void LetsGetFancyWithABool() //Chapter 3 is telling me about bools so I'm going to make one matter because I know how to if/else
    {
        Debug.LogWarning("<color=yellow>-----[Just boolean around]-----</color>");

        if (knowWhatABooleanIs != true)
        {
            Debug.Log($"Boolean knowledge unticked in the inspector! Is it {currentAge} or something?");
        }
        else
        {
            Debug.Log($"Congrats! You ticked the Boolean Box! {addedAge} ... Nice!");
        }

    }

}

[Serializable] //I've learned that this is required when nesting a class under the main class/monobehaviour. Can be "System.Serializable" if not using System; at the top.
/* I believe everything needs to be public as well, and this puts it all in a nice little dropdown in the inspector.
It is apparently ill advised to use more than one monobehaviour, which could have also worked here.*/
public class PostOffice
{
    //Post Office variables
    [Header("Post Office")]
    public string postOfficeAddress = "1234 Letter Opener Drive";
    public string recipientAddress = "2911 Numerology Way";

    //Post Office Methods
    public void DeliverMail()
    {
        Debug.Log($"Mail delivered to {recipientAddress} from postal truck registered to {postOfficeAddress}");
    }

    public void SendMail()
    {
        Debug.Log($"Mail received at {postOfficeAddress} from resident at {recipientAddress}");
    }
}

[Serializable]
public class EnumPractice
{
    public enum cardinalDirections {North, South, East, West}
    public enum legendaryBirds{Articuno, Zapdos, Moltres, Lugia, Hooh}
    public enum legendaryDogs {Suicune, Raikou, Entei}

    [Header("Simply the Best enums")]
    public cardinalDirections kingOfThe = cardinalDirections.North;
    public legendaryBirds bestBirb = legendaryBirds.Hooh;
    public legendaryDogs bestDoggo = legendaryDogs.Suicune;

    public void PrintTheBestEnum()
    {
        Debug.Log($"Jon Snow is the true king of the {kingOfThe}.\nThe best birb is {bestBirb}.\nThe bestest doggo is {bestDoggo}.");
    }

    public void PlayerOneChoice()
    {
        bestBirb.ToString();
    }

    public void PlayerTwoChoice()
    {
        bestDoggo.ToString();
    }

}