using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class Hiel : MonoBehaviourPunCallbacks
{

    public Spawn_script spawn;

    private Vector3 position;

    public GameObject cam_cine_Hiel; 
    

    // Update is called once per frame
    void Update()
    {
        bool Einput = Input.GetKeyDown(KeyCode.E);
        if (Einput)
        {
            Vector3 interact = GetComponent<Interactable>().transform.position;
            position = spawn.clone1.transform.position;
            Vector3 diff = position - interact;
            #region check if pos is valid

            if (diff.x < 0)
            {
                diff.x *= -1;
            }

            if (diff.z < 0)
            {
                diff.z *= -1;
            }

            if (diff.y < 0)
            {
                diff.y *= -1;
            }

            #endregion
            float rad = GetComponent<Interactable>().radius;
            if (diff.x < rad && diff.y < rad && diff.z < rad)
                Interaction_Hiel();
        }

    }



    private void Set_UnsetCam(bool state)
        {
            if (PhotonNetwork.IsMasterClient)
                spawn.clone1.transform.Find("Character").transform.Find("GameObject").transform.Find("player_cam").gameObject.SetActive(state);
            else 
                spawn.clone2.transform.Find("Character").transform.Find("GameObject").transform.Find("player_cam2").gameObject.SetActive(state);
        }

        private void Set_UnsetMov(bool state)
        {
            if (PhotonNetwork.IsMasterClient)
                spawn.clone1.GetComponent<moves>().enabled = state; 
            else 
                spawn.clone2.GetComponent<moves>().enabled = state; 
        }
   
        private IEnumerator Bakto_normal(GameObject camera, float delay)
        {
            yield return new WaitForSeconds(delay); 
            Set_UnsetCam(true);
            Set_UnsetMov(true);
            camera.SetActive(false);
        }

        private void Cam_cinematique(GameObject camera, float delay)
        {
            Set_UnsetCam(false);
            Set_UnsetMov(false);
            camera.SetActive(true);
            
        }


        public void Interaction_Hiel()
        {
            Cam_cinematique(cam_cine_Hiel, 0);

            //StartCoroutine(Bakto_normal(camera, delay));
        }
        
}
