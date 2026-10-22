using UnityEngine;

public class MonsterChase : MonoBehaviour
{
    public Transform player;
    public float followDistance = 6f;
    public float smoothTime = 0.15f;

    private Vector3 smoothVelocity;

    void LateUpdate()
    {
        if (player == null)
            return;

        // Stay behind the player and follow their lane
        Vector3 targetPosition = new Vector3(
            player.position.x,
            transform.position.y,
            player.position.z - followDistance
        );

        transform.position = Vector3.SmoothDamp(
            transform.position,
            targetPosition,
            ref smoothVelocity,
            smoothTime
        );
    }
}