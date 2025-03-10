using System;
using UnityEngine;

public class ParticleSpawnerOnCollision : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem particle;
    
    public float distanceBeforeSpawn = .1f;
    
    private Vector3 lastSpawnPosition;
    
    public void Start()
    {
        lastSpawnPosition = transform.position;
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Should spawn particle");
        if (Vector3.Distance(lastSpawnPosition, transform.position) > distanceBeforeSpawn)
        {
            lastSpawnPosition = transform.position;
            
            // ray cast towards the other object
            var direction = other.transform.position - transform.position;
            var ray = new Ray(transform.position, direction);
            if (Physics.Raycast(ray, out var hit))
            {
                var emitParams = new ParticleSystem.EmitParams();
                emitParams.position = hit.point;
                particle.Emit(emitParams, 1);
            }
        }
    }
}
