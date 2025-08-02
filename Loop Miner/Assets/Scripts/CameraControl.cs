using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [Header("Kamera prati igraca")]
    [SerializeField] private Transform player;
    [SerializeField] private float aheadDistance;
    [SerializeField] private float cameraSpeed;
    private float lookAhead;

    private void FixedUpdate()
    {     
        if(player != null)
        {
            transform.position = new Vector3(transform.position.x, player.position.y + lookAhead, transform.position.z);
            lookAhead = Mathf.Lerp(lookAhead, (aheadDistance * player.localScale.y), cameraSpeed * Time.deltaTime);
        }
        
    }
}
