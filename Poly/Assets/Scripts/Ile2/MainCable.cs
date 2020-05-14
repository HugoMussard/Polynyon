using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCable : MonoBehaviour
{
    
    public Material material_principal;

    public GameObject cable1;
    public GameObject cable2; 
    public GameObject cable3; 
    public GameObject cable4; 
    public GameObject cable5; 
    public GameObject cable6;

    public Material coul1; 
    public Material coul2; 
    public Material coul3; 
    public Material coul4; 
    public Material coul5; 
    public Material coul6; 
    
    public Interactable lever1;
    public Interactable lever2;
    public Interactable lever3;
    public Interactable lever4;
    public Interactable lever5;
    public Interactable lever6;

    public GameObject tw1;
    public GameObject tw2; 
    public GameObject tw3; 
    public GameObject tw4; 
    public GameObject tw5; 
    public GameObject tw6;

    public GameObject ak1;
    public GameObject ak2; 
    public GameObject ak3; 
    public GameObject ak4; 
    public GameObject ak5; 
    public GameObject ak6;

    private List<GameObject> _cables;
    private List<GameObject> _tws;
    private List<GameObject> _aks;

    private bool check = false;

    private bool mybool1 = false; 
    private bool mybool2 = false; 
    private bool mybool3 = false; 
    private bool mybool4 = false; 
    private bool mybool5 = false; 
    private bool mybool6 = false;

    private int validCables = 0;
    private int i = 0;
    
    
    void Start()
    {
        coul1.color = new Color(coul1.color.r, coul1.color.g, coul1.color.b, 1);
        coul2.color = new Color(coul2.color.r, coul2.color.g, coul2.color.b, 1);
        coul3.color = new Color(coul3.color.r, coul3.color.g, coul3.color.b, 1);
        coul4.color = new Color(coul4.color.r, coul4.color.g, coul4.color.b, 1);
        coul5.color = new Color(coul5.color.r, coul5.color.g, coul5.color.b, 1);
        coul6.color = new Color(coul6.color.r, coul6.color.g, coul6.color.b, 1);
        
        _cables = new List<GameObject>() {cable1, cable2, cable3, cable4, cable5, cable6};
        _tws = new List<GameObject>() {tw1, tw2, tw3, tw4, tw5, tw6};
        _aks = new List<GameObject>() {ak1, ak2, ak3, ak4, ak5, ak6};

        for(int j = 0; j < _cables.Count; j++)
            if (ToCut(_tws[j], _aks[j], _cables[j]))
            {
                Debug.Log(j);
                validCables++;
            }
        Debug.Log(validCables);
        
        PlayerPrefs.SetInt("LTcables", 0);
        PlayerPrefs.Save();

    }


    private bool ToCut(GameObject symb1, GameObject symb2, GameObject cable)
    {
        Color couleur = cable.GetComponent<Renderer>().sharedMaterial.color;
        if (couleur.b == 1)
        {
            if (symb1.activeSelf ^ symb2.activeSelf)
                return true;
        }
        
        if (couleur.r == 1)
        {
            if (symb1.activeSelf && symb2.activeSelf)
                return true;
        }
        return false;
    }
    
    
    // Update is called once per frame
    void Update()
    {

        if (lever1.state != mybool1)
        {
            if (ToCut(_tws[0], _aks[0], _cables[0]))
            {
                coul1.color = new Color(coul1.color.r, coul1.color.g, coul1.color.b, 0);
                i++;
            }
            else PlayerPrefs.SetInt("LTcables", PlayerPrefs.GetInt("LTcables") + 1);
            mybool1 = lever1.state;
        }
        
        if (lever2.state != mybool2)
        {
            if (ToCut(_tws[1], _aks[1], _cables[1]))
            {
                coul2.color = new Color(coul2.color.r, coul2.color.g, coul2.color.b, 0);
                i++;
            }
            mybool2 = lever2.state; 
        }
        
        if (lever3.state != mybool3)
        {
            if (ToCut(_tws[2], _aks[2], _cables[2]))
            {
                coul3.color = new Color(coul3.color.r, coul3.color.g, coul3.color.b, 0);
                i++;
            }
            mybool3 = lever3.state; 
        }
        
        if (lever4.state != mybool4)
        {
            if (ToCut(_tws[3], _aks[3], _cables[3]))
            {
                coul4.color = new Color(coul4.color.r, coul4.color.g, coul4.color.b, 0);
                i++;
            }
            mybool4 = lever4.state; 
        }
        
        if (lever5.state != mybool5)
        {
            if (ToCut(_tws[4], _aks[4], _cables[4]))
            {
                coul5.color = new Color(coul5.color.r, coul5.color.g, coul5.color.b, 0);
                i++;
            }
            mybool5 = lever5.state; 
        }
        if (lever6.state != mybool6)
        {
            if (ToCut(_tws[5], _aks[5], _cables[5]))
            {
                coul6.color = new Color(coul6.color.r, coul6.color.g, coul6.color.b, 0);
                i++;
            } 
            mybool6 = lever6.state; 
        }

        if (i == validCables) 
            material_principal.color = new Color(0, 1, 0);
    }
}
