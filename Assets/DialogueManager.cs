using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI text;
    public TextMeshProUGUI characterName;
    public TextMeshProUGUI response1;
    public TextMeshProUGUI response2;

    Node CurrentNode;

    public Image image;
    public Image largeImage;

    class Node {
        public List<NodeOptions> Options = new List<NodeOptions> ();
        public string Text;
        public string CharacterName;
        public string IconPath;

        public string background_path;

        public UnityEvent onRender = new UnityEvent();
        
        public Node(string prompt, string character, List<NodeOptions> options, string path, string image) {
            Options = options;
            Text = prompt;
            CharacterName = character;
            IconPath = path;
            background_path = image;
        }
        public Node(string prompt, string character, List<NodeOptions> options) {
            Options = options;
            Text = prompt;
            CharacterName = character;
        }
    }

    class NodeOptions {
        public string prompt;
        public Node node;
        public bool restartGame;

        public NodeOptions(string prompt, bool restartGame = false) {
            this.prompt=prompt;
            this.restartGame=restartGame;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Option 1
        var placeholderOptions = new List<NodeOptions>();
        placeholderOptions.Add(new NodeOptions("Open Door", false)); // 0
        placeholderOptions.Add(new NodeOptions("Go back to bed", false)); // 1
        Node ph1 = new Node(
            "King Henry, your Majesty! I have urgent news, if you may open the door?", // Message
            "Advisor", // Character Name
            placeholderOptions, // Buttons
            "Sprites/LOTKAdvisor", //Character Sprite Path
            "Sprites/King bedroom" // Background Sprite Path
        );

        // Open Door
        var placeholderOptions2 = new List<NodeOptions>();
        placeholderOptions2.Add(new NodeOptions("Okay.", false)); // 0
        placeholderOptions2.Add(new NodeOptions("Okay.", false)); // 1
        Node ph2 = new Node("Good day, your Majesty. I bear a message.", 
        "Advisor", 
        placeholderOptions2,
        "Sprites/LOTKAdvisor",
        "Sprites/LOTKAdvisor");

        // Go back to bed
        var placeholderOptions3 = new List<NodeOptions>();
        placeholderOptions3.Add(new NodeOptions("Okay.", false)); // 0
        placeholderOptions3.Add(new NodeOptions("Okay.", false)); // 1
        Node ph3 = new Node(" Your Majesty? Your Majesty? You must have fallen back to bed. No matter, I have a key!  I apologize for the interruption, My King, but I bear a message from Queen Catherine.", 
        "Advisor", 
        placeholderOptions3,
        "Sprites/LOTKAdvisor",
        "Sprites/King bedroom");

        // Option 2
        var placeholderOptions4 = new List<NodeOptions>();
        placeholderOptions4.Add(new NodeOptions("Order Collection to Proceed", false)); // 0
        placeholderOptions4.Add(new NodeOptions(" Hand it off to the Cardinal", false)); // 1
        Node ph4 = new Node(" It is tax season, My King, I am afraid you must order for the collection to proceed. "
        , "Advisor"
        , placeholderOptions4,
        "Sprites/LOTKAdvisor",
        "Sprites/LOTKAdvisor");
       
       // Proceed to Next
        var placeholderOptions5 = new List<NodeOptions>();
        placeholderOptions5.Add(new NodeOptions("Okay.", false)); // 0
        placeholderOptions5.Add(new NodeOptions("Okay.", false)); // 1
        Node ph5 = new Node(" Excellent, I'll leave you to continue on with the rest of your day unless something silly like a natural disaster has come to end your kingdom!",
        "Advisor", 
        placeholderOptions5,
        "Sprites/LOTKAdvisor",
        "Sprites/LOTKAdvisor");

        // Hand it off to Cardinal
        var placeholderOptions6 = new List<NodeOptions>();
        placeholderOptions6.Add(new NodeOptions("Okay.", false)); // 0
        placeholderOptions6.Add(new NodeOptions("Okay.", false)); // 1
        Node ph6 = new Node("But your Majesty! It is fine, I will do it myself...",
        "Advisor", 
        placeholderOptions6,
        "Sprites/LOTKAdvisor",
        "Sprites/LOTKAdvisor");

        // Option 3
        var placeholderOptions7 = new List<NodeOptions>();
        placeholderOptions7.Add(new NodeOptions("Invade Other Countries", false)); // 0
        placeholderOptions7.Add(new NodeOptions("Try to bare through", false)); // 1
        Node ph7 = new Node(
        "WARNING! We have received information that has put us on the brink of crisis. The last country that had a drought fell within five years. The people that did not die dispersed into Europe. We must create an action plan. We cannot rely on our allies. Only ourselves.",
        "Advisor",
         placeholderOptions7,
         "Sprites/LOTKAdvisor",
         "Sprites/DroughtBackground");
       
        // Try to bare through Ending 1
        var placeholderOptions8 = new List<NodeOptions>();
        placeholderOptions8.Add(new NodeOptions("Return")); // 0
        placeholderOptions8.Add(new NodeOptions("Return")); // 1
        Node ph8 = new Node(
        "Unfortunately, it appears the same fate has befallen us. Our policies have led to food and water shortages as well as many deaths. Our subjects have begun revolting in the streets, with our armies unable to fend them off. I fear this is the end of our kingdom.",
        "Advisor",
        placeholderOptions8,
        "Sprites/LOTKAdvisor",
        "Sprites/PopGraph");

        // Invade Country
        var placeholderOptions9 = new List<NodeOptions>();
        placeholderOptions9.Add(new NodeOptions("Invade Scotland!", false)); // 0
        placeholderOptions9.Add(new NodeOptions("Invade France!", false)); // 1 
        Node ph9 = new Node("If war is what we have decided, then I must urge you to consider the state we are in. We cannot invade two countries at the same time, especially when we are going to become weak from the drought. While we have a better chance at successfully invading France and Scotland than our other neighbors, we must decide which.",
        "Advisor", 
        placeholderOptions9,
        "Sprites/LOTKAdvisor",
        "Sprites/LOTKAdvisor");

        // Invade France 
        var placeholderOptions10 = new List<NodeOptions>();
        placeholderOptions10.Add(new NodeOptions("Return")); // 0
        placeholderOptions10.Add(new NodeOptions("Return")); // 1 
        Node ph10 = new Node("You spend many days and many nights planning for the invasion. Though your armies were well equipped and prepared, you underestimated the strength and tenacity of the French and were ultimately defeated and humiliated. We can no longer fund such a war effort or even maintain our armies and hold to power. This threatens the security of England.",
        "Advisor",
        placeholderOptions10,
        "Sprites/LOTKAdvisor",
        "Sprites/Battlefield_Sketch");

        // Invade Scotland
        var placeholderOptions11 = new List<NodeOptions>();
        placeholderOptions11.Add(new NodeOptions("Stealth!", false)); // 0
        placeholderOptions11.Add(new NodeOptions("Overwhelming force!", false)); // 1 
        Node ph11 = new Node(
        "Myself and your generals should be able to handle most of the tactical decisions, and you will only be needed to look heroic on the field of battle. However, I must ask about our overall strategy. Would you prefer to go in, with a strong invasion force using a great amount of troops, or would you prefer to go for a more stealthy approach with less troops?.",
        "Advisor", 
        placeholderOptions11, 
        "Sprites/LOTKAdvisor",
        "Sprites/LOTKAdvisor");

        // Invade Scotland LOUD
        var placeholderOptions12 = new List<NodeOptions>();
        placeholderOptions12.Add(new NodeOptions("Go with the General", false)); // 0
        placeholderOptions12.Add(new NodeOptions("Admit Defeat", false)); // 1 
        Node ph12 = new Node(
        " YOUR MAJESTY! WE NEED YOUR HELP! IT’S THE SCOTTISH! THEY WERE PREPARED! We managed to capture a few key points, but we lost momentum and many men as we had to break through their strongholds and weather their ambushes.",
         "Advisor", 
         placeholderOptions12,
         "Sprites/LOTKAdvisor",
         "Sprites/Battlefield_Sketch");

        // Admit defeat against Scotland
        var placeholderOptions13 = new List<NodeOptions>();
        placeholderOptions13.Add(new NodeOptions("Return")); // 0
        placeholderOptions13.Add(new NodeOptions("Return")); // 1 
        Node ph13 = new Node("You are forced to conditionally surrender and give up a portion of land as well as reparations, afterwards learning that your wife has been having an affair with Thomas Culpepper, a Gentleman of the King’s Privy Chamber. Regrettably, you are forced to execute them both. Truly, you are the worst king England has seen, and the peasant revolts which force you to flee the country certainly show that.",
        "Advisor", 
        placeholderOptions13,
        "Sprites/LOTKAdvisor",
        "Sprites/Battlefield_Sketch");

        // Go with general ending
        var placeholderOptions14 = new List<NodeOptions>();
        placeholderOptions14.Add(new NodeOptions("Return")); // 0
        placeholderOptions14.Add(new NodeOptions("Return")); // 1 
        Node ph14 = new Node(
        "Your Majesty. I believe we’ve lost. There is nothing we can do. You flee back to England with your tail between your legs, in the process giving up a large portion of land to Scotland in order to appease them. Shortly afterwards, you learn that your wife has been having an affair with Thomas Culpepper, a Gentleman of the King’s Privy Chamber. Regrettably, you are forced to execute them both. Truly, you are the worst king England has seen, and the peasant revolts which force you to flee the country certainly show that.", 
        "Advisor", 
        placeholderOptions14,
        "Sprites/LOTKAdvisor",
        "Sprites/Battlefield_Sketch");

        // Invade Scotland quietly and WIN!
        var placeholderOptions15 = new List<NodeOptions>();
        placeholderOptions15.Add(new NodeOptions("Return")); // 0
        placeholderOptions15.Add(new NodeOptions("Return")); // 1 
        Node ph15 = new Node(
        "After many days of harsh fighting, the Scots have been defeated, and the rest of their forces have either laid down arms or scattered. Victory has come for England!",
        "Advisor", 
        placeholderOptions15,
        "Sprites/LOTKAdvisor",
        "Sprites/PlayerWin");

        // Register Options
        placeholderOptions[0].node = ph2;
        placeholderOptions[1].node = ph3;

        placeholderOptions2[0].node = ph4;
        placeholderOptions2[1].node = ph4;

        placeholderOptions4[0].node = ph5;
        placeholderOptions4[1].node = ph6;

        placeholderOptions5[0].node = ph7;
        placeholderOptions5[1].node = ph7;

        placeholderOptions6[0].node = ph7;
        placeholderOptions6[1].node = ph7;
        
        placeholderOptions7[0].node = ph9;
        placeholderOptions7[1].node = ph8;

        placeholderOptions9[0].node = ph11;
        placeholderOptions9[1].node = ph10;

        placeholderOptions11[0].node = ph15;
        placeholderOptions11[1].node = ph12;

        placeholderOptions12[0].node = ph13;
        placeholderOptions12[1].node = ph14;

        placeholderOptions3[0].node = ph4;
        placeholderOptions3[1].node = ph4;

        // RETURN AFTER ENDING
        placeholderOptions15[0].node = ph1;
        placeholderOptions15[1].node = ph1;

        placeholderOptions13[0].node = ph1;
        placeholderOptions13[1].node = ph1;

        placeholderOptions14[0].node = ph1;
        placeholderOptions14[1].node = ph1;

        placeholderOptions10[0].node = ph1;
        placeholderOptions10[1].node = ph1;

        placeholderOptions8[0].node = ph1;
        placeholderOptions8[1].node = ph1;

        // Register Events

        ph2.onRender.AddListener(() => {
            //letter
        });

        CurrentNode = ph1;
        RenderNode(CurrentNode);
    }

    public void RenderFromButton(int index) {
        if(CurrentNode.Options[index].restartGame) {
            RestartGame();
        }
        if(CurrentNode.Options[index].node != null) {
            CurrentNode = CurrentNode.Options[index].node;
            RenderNode(CurrentNode);
        }
    }

    void RestartGame() {
        throw new NotImplementedException();
    }

    void RenderNode(Node node) {
        largeImage.sprite = Resources.Load<Sprite>(node.background_path);
        text.text = node.Text;
        characterName.text = node.CharacterName;
        response1.text = node.Options[0].prompt;
        response2.text = node.Options[1].prompt;
        image.sprite = Resources.Load<Sprite>(node.IconPath);
        node.onRender.Invoke();
    }
}
