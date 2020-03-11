
using UnityEngine;

public class Doors : MonoBehaviour
{
    public Transform door;
    public Interactable opener;
    float speed = - 0.2f;
    Collider collider;
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (opener.state)
        {
            collider.enabled = false;
            Vector3 move = new Vector3(0, speed,0);
            door.up = (door.up - move ) * Time.deltaTime;
        }
    }
}
