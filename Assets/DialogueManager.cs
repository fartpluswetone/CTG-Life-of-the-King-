using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI text;
    public TextMeshProUGUI characterName;
    public TextMeshProUGUI response1;
    public TextMeshProUGUI response2;
    Node CurrentNode;

    class Node {
        public List<NodeOptions> Options = new List<NodeOptions> ();
        public string Text;
        public string CharacterName;

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
        // Register Nodes
        var placeholderOptions = new List<NodeOptions>();
        placeholderOptions.Add(new NodeOptions("Placeholder 1", false)); // 0
        placeholderOptions.Add(new NodeOptions("dodofart", false)); // 1
        Node ph1 = new Node("I am a placeholder.", "null", placeholderOptions);

        var placeholderOptions2 = new List<NodeOptions>();
        placeholderOptions2.Add(new NodeOptions("Cheese")); // 0
        placeholderOptions2.Add(new NodeOptions("Eggs", true)); // 1
        Node ph2 = new Node("I am a placeholder too.", "null", placeholderOptions2);

        var placeholderOptions3 = new List<NodeOptions>();
        placeholderOptions3.Add(new NodeOptions("Cheese")); // 0
        placeholderOptions3.Add(new NodeOptions("Eggs", true)); // 1
        Node ph3 = new Node("I am a placeholder tree.", "null", placeholderOptions3);


        // Register Options
        placeholderOptions[0].node = ph2;
        placeholderOptions[1].node = ph3;

        placeholderOptions2[0].node = ph1;
        placeholderOptions2[1].node = ph1;

        placeholderOptions3[0].node = ph1;
        placeholderOptions3[1].node = ph1;


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
        text.text = node.Text;
        characterName.text = node.CharacterName;
        response1.text = node.Options[0].prompt;
        response2.text = node.Options[1].prompt;
    }
}
