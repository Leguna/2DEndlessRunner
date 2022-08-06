using UnityEngine;

public class DestroyInDistance : MonoBehaviour
{
    private Transform _target;

    private void Start()
    {
        _target = GameManager.Instance.playerGameObject.transform;
    }

    private void Update()
    {
        if (Vector3.Distance(_target.position, transform.position) > IntegerConstant.DestroyDistance)
            Destroy(gameObject);
    }
}
