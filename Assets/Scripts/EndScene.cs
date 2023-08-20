using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScene : MonoBehaviour
{
    bool checkEnd;
    Dialogue dialogue;
    public GameObject roboDialogue;
    public GameObject firstHalf;
    public GameObject secondHalf;
    GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        dialogue = roboDialogue.GetComponent<Dialogue>();
        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        checkEnd = dialogue.checkEnd();
        if (checkEnd) {
            playEndScene();
        }
    }

    void playEndScene() {
        firstHalf.SetActive(false);
        player.SetActive(false);
        secondHalf.SetActive(true);
        print("here");
        
    }

    
}
