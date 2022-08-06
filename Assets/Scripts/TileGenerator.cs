using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TileGenerator : MonoBehaviour
{
    [SerializeField] private List<GroundTemplateConfig> tileTemplates;
    [SerializeField] private Transform lastPositionSpawn;
    [SerializeField] private Transform playerPos;
    [SerializeField] private Transform groundParent;
    [SerializeField] private Vector2 distanceGenerate;
    [SerializeField] private float lastPositionOffset = 1;
    [SerializeField] private int lastEmptyReset = 8;
    private int _lastEmpty = 4;

    private void Update()
    {
        var distance = Vector3.Distance(lastPositionSpawn.position, playerPos.position);
        print(distance);
        if (distance > distanceGenerate.x && distance < distanceGenerate.y)
        {
            var randomTemplateNumber = Random.Range(0, tileTemplates.Count);
            while (randomTemplateNumber == 4)
            {
                if (_lastEmpty > 0)
                {
                    randomTemplateNumber = Random.Range(0, tileTemplates.Count);
                    _lastEmpty -= 1;
                }
                else
                {
                    _lastEmpty = lastEmptyReset;
                    break;
                }
            }

            var groundTemplateData = tileTemplates[randomTemplateNumber];
            var position = lastPositionSpawn.position;
            var spawnedPos = Instantiate(groundTemplateData.prefab, position,
                Quaternion.identity, groundParent);
            var targetXLastPos = groundTemplateData.size + lastPositionOffset;
            lastPositionSpawn.Translate(targetXLastPos, 0, 0);
        }
    }
}

[Serializable]
public struct GroundTemplateConfig
{
    public string name;
    public float size;
    public GameObject prefab;
}
