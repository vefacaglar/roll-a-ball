using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        offset = transform.position - player.transform.position;
        
    }

    void LateUpdate()
    {
        // if the player has been destroyed, stop updating the camera to
        // avoid MissingReferenceException.  Unity returns true for == null
        // on destroyed objects, so check before accessing transform.
        if (player == null)
        {
            enabled = false; // optional: freeze camera in place
            return;
        }

        transform.position = player.transform.position + offset;
    }
}
