using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class GoGo : MonoBehaviour
{
    // Start is called before the first frame update
    public goenigm go1;
    public goenigm go2;
    public string load;
    bool go;
    float time;
    void Start()
    {
        time = 0;
        go = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (go1.state && go2.state)
        {
            if (time == 0)
            {
                time = Time.realtimeSinceStartup;
            }
            if (Time.realtimeSinceStartup - time >= 3)
                go = true;
        }
        else
        {
            time = 0;
        }
        if (go && PhotonNetwork.IsMasterClient)
        {
            SceneManager.LoadScene(load);
        }
    }
}