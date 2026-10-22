using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;

    public Vector3 offset = new Vector3(0f, 5f, -6f);

    public float followSpeed = 8f;
    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        if (player == null)
            return;

        Vector3 targetPosition = player.position + offset;

        transform.position = Vector3.SmoothDamp(
                transform.position,
                targetPosition,
                ref velocity,
                0.1f
        );

        transform.LookAt(player.position + Vector3.up * 1.5f);
    }
}