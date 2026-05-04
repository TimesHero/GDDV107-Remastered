using UnityEngine;

public class DayTwoPractice : MonoBehaviour
{
    [Header("Week 2 Practice")]
    //Textbook example showcasing how variables act as placeholders
    public int currentAge = 30;
    public int addedAge = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ComputeAge(); //will print both Debug.Log() statements to the console
        PostOffice.DeliverMail();
        PostOffice.SendMail();
    }

    public void ComputeAge() //went a little above and beyond here and made a method for currentAge practice
    {
        Debug.LogWarning($"<yellow>-----[ComputeAge]-----");
        Debug.Log($"Hard coded Values 30 + 1 = {30 + 1}"); //Hard coded example
        Debug.Log($"Added 'currentAge + 1' = {currentAge +1}"); //calls on the public variable that can be changed in the inspector
        Debug.Log($"Adding currentAge with addedAge variables gets you {currentAge + addedAge}"); //puts both int variables together
    }

    public void PostageParse()
    {
        
    }

}

public class PostOffice
{
    //Post Office variables
    [Header("Post Office")]
    public string postOfficeAddress = "1234 Letter Opener Drive";
    public string recipientAddress = "2911 Numerology Way";

    //Post Office Methods
    DeliverMail()
    {
        Debug.Log($"Mail delivered to {recipientAddress} from postal truck registered to {postOfficeAddress}");
    }

    SendMail()
    {
        Debug.Log($"Mail received at {postOfficeAddress} from resident at {recipientAddress}");
    }
}
