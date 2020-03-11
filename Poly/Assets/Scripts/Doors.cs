
using UnityEngine;

public class Doors : MonoBehaviour
{
    public Transform door;
    public Interactable opener;
    float speed = - 0.2f;
    float t;
    Vector3 startPosition;
    Vector3 target;
    float timeToReachTarget;
    //Collider collider;
    
  

    public void Glissement()
    {
        if (opener.state)
        {
            //collider.enabled = false;
            transform.Translate(Vector3.down * (Time.deltaTime * 5.0f));
            
        }
    }
    
    void Update()
    {
        if (opener.state && transform.position.y > -3.5f)
        {
            //collider.enabled = false;
            transform.Translate(Vector3.down * (Time.deltaTime * 1.0f));
            
        }
    }
}
