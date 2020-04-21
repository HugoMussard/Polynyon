using UnityEngine;
//on essaye de voir ce que ca donne
public class Interactable : MonoBehaviour
{
    public float radius = 3f;
    public bool state = false;
    void OnDrawGizmosSelected ()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
   
}
