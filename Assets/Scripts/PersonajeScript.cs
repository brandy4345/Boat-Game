using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class PersonajeScript : MonoBehaviour
{

    //[Header("Animacion")]
    //private Animator animator;

    [SerializeField] private float SpeedRotation;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float Speed;

    private Vector3 v = Vector3.zero;
    
    float tiempo = 0;
    public float tiempoDeTransicion = 2f; // Tiempo de transición en segundos
    
    Rigidbody rb;

    private bool estaRotando = false;


    // Start is called before the first frame update
    void Start()
    {
        //animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float mov = Input.GetAxisRaw("Horizontal");
        //animacion("Rotar", mov);


        estaRotando = Input.GetKey(KeyCode.A) ^ Input.GetKey(KeyCode.D);
        //animacion("PosRot", estaRotando);
        bool Adelante = Input.GetKey(KeyCode.W);
        if (estaRotando)
        {
            transform.Rotate(0, mov * Mathf.Rad2Deg * SpeedRotation * Time.deltaTime,0 );
        }
        if (Adelante)
        {
            //animacion("Mov", true);

            
            if (rb.velocity.magnitude <= maxSpeed)
            {

                rb.velocity += transform.forward * Speed * Time.deltaTime;
                v = rb.velocity;
            }
            else if (tiempo<=2)
            {
                float porcentaje = Mathf.Clamp01(tiempo / tiempoDeTransicion);
                Vector3 vel = Vector3.Lerp(v, transform.forward * rb.velocity.magnitude, porcentaje);
                rb.velocity = vel;
                tiempo += Time.deltaTime;

            }
            else
            {
                rb.velocity = transform.forward * rb.velocity.magnitude;
            }
            
        }
        else
        {
            //animacion("Mov", false);

            if (rb.velocity.magnitude >= 0)
            {

               rb.velocity -= rb.velocity * Speed * Time.deltaTime;

            }

            tiempo = 0;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1;
        }
    }
    /*
    void animacion(string a, bool b)
    {
        animator.SetBool(a, b);
    }
    void animacion(string a, float b)
    {
        animator.SetFloat(a, b);
    }
   */
}

