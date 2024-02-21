using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailComponent : MonoBehaviour
{
    [SerializeField] private float speed;

    private TrailRenderer trail;

    private float timeFade = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        trail = GetComponent<TrailRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (trail.time <= timeFade)
        {
            // Calcular la dirección perpendicular al movimiento actual.

            // Aplicar la velocidad perpendicular.
            Vector3 newPosition = transform.position + Vector3.left * speed* Time.deltaTime;
            transform.position = newPosition;
        }
    }
}
