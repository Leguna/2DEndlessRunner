using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Position")] public Transform player;
    public float horizontalOffset;
    public float verticalOffset;

    private void Update()
    {
        var currentTransform = transform;
        Vector3 newPosition = currentTransform.position;
        var position = player.position;
        newPosition.x = position.x + horizontalOffset;
        currentTransform.position = newPosition;
    }
}
