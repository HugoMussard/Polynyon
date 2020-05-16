using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = System.Random;

public class TW_AK_Ile2 : MonoBehaviour
{

    public GameObject TW1;
    public GameObject TW2;
    public GameObject TW3; 
    public GameObject TW4; 
    public GameObject TW5; 
    public GameObject TW6; 
    public GameObject AK1;
    public GameObject AK2;
    public GameObject AK3; 
    public GameObject AK4; 
    public GameObject AK5; 
    public GameObject AK6;
    Random rnd = new Random();

    private int total = 0; 

    private int tw1;
    private int tw2;
    private int tw3;
    private int tw4;
    private int tw5;
    private int tw6;
    private int ak1;
    private int ak2;
    private int ak3;
    private int ak4;
    private int ak5;
    private int ak6;
    
    // Start is called before the first frame update
    void Start()
    { 
        while (total < 5) Init();
        
        if (tw1 == 1) TW1.SetActive(true);
        if (tw2 == 1) TW2.SetActive(true);
        if (tw3 == 1) TW3.SetActive(true);
        if (tw4 == 1) TW4.SetActive(true);
        if (tw5 == 1) TW5.SetActive(true);
        if (tw6 == 1) TW6.SetActive(true);
        
        if (ak1 == 1) AK1.SetActive(true);
        if (ak2 == 1) AK2.SetActive(true);
        if (ak3 == 1) AK3.SetActive(true);
        if (ak4 == 1) AK4.SetActive(true);
        if (ak5 == 1) AK5.SetActive(true);
        if (ak6 == 1) AK6.SetActive(true);
    }

    private void Init()
    {
        if ((tw1 = rnd.Next(2)) == 1) total++;
        if ((tw2 = rnd.Next(2)) == 1) total++;
        if ((tw3 = rnd.Next(2)) == 1) total++;
        if ((tw4 = rnd.Next(2)) == 1) total++;
        if ((tw5 = rnd.Next(2)) == 1) total++;
        if ((tw6 = rnd.Next(2)) == 1) total++;
        if ((ak1 = rnd.Next(2)) == 1) total++;
        if ((ak2 = rnd.Next(2)) == 1) total++;
        if ((ak3 = rnd.Next(2)) == 1) total++;
        if ((ak4 = rnd.Next(2)) == 1) total++;
        if ((ak5 = rnd.Next(2)) == 1) total++;
        if ((ak6 = rnd.Next(2)) == 1) total++;
    }

}
