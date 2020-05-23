using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using Random = System.Random;


public class Mdp_enigme : MonoBehaviourPunCallbacks
{
    public GameObject lettre1;
    public GameObject lettre2;
    public GameObject lettre3;
    public GameObject lettre4;
    public GameObject lettre5;

    public LetterUPDOWN script1;
    public LetterUPDOWN script2;
    public LetterUPDOWN script3;
    public LetterUPDOWN script4;
    public LetterUPDOWN script5;

    private List<GameObject> tab_lettres;
    private List<LetterUPDOWN> tab2;

    public Material material;
    

    private string[] bank = {"AAAAA"}; 
    Random rnd = new Random();

    private int nb;
    private string word;

    public Cinematique_End script_end;

    private bool fin;
    


    [PunRPC]
    private void End()
    {
        script_end.Finishmdp = true;
    }
    
    private void Start()
    {
        material.color = new Color(1, 1, 1, 1);
        tab_lettres = new List<GameObject>() {lettre1, lettre2, lettre3, lettre4, lettre5};
        tab2 = new List<LetterUPDOWN>() {script1, script2, script3, script4, script5};
        nb = rnd.Next(bank.Length);
        word = bank[nb]; 
        Debug.Log(word);
        for (int i = 0; i < 5; i++)
            tab_lettres[i].gameObject.transform.Find(Convert.ToString(word[i])).gameObject.SetActive(true);
        
    }


    private bool CheckMdp()
    {
        for (int j = 0; j < 5; j++)
        {
            if (tab2[j].actualLetter.name != Convert.ToString(word[j]))
                return false;
        }
        return true; 
    }


    private void Update()
    {
        if (CheckMdp() && !fin)
        {
            material.color = new Color(0, 1, 0, 1);
            photonView.RPC("End", RpcTarget.All);
            fin = true; 
        }
    }
}
