using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    public float velocidad = 10f; // Velocidad de movimiento del objeto
    public float salto = 10f; // Fuerza del salto
    public float limiteIzquierdo = -5f; // L�mite izquierdo del movimiento
    public float limiteDerecho = 5f; // L�mite derecho del movimiento

    bool enElSuelo = true; // Indica si el objeto est� en el suelo

    void Update()
    {
        float movimientoHorizontal = Input.GetAxis("Horizontal"); // Obtiene la entrada del teclado en el eje horizontal
        float movimientoVertical = Input.GetAxis("Vertical"); // Obtiene la entrada del teclado en el eje vertical

        Vector3 movimiento = new Vector3(movimientoHorizontal, 0f, movimientoVertical); // Combina los movimientos horizontal y vertical

        transform.Translate(movimiento * velocidad * Time.deltaTime); // Mueve el objeto en ambos ejes

        // Limita el movimiento del objeto dentro de los l�mites establecidos
        float posicionX = Mathf.Clamp(transform.position.x, limiteIzquierdo, limiteDerecho);
        transform.position = new Vector3(posicionX, transform.position.y, transform.position.z);

        if (Input.GetKeyDown(KeyCode.Space) && enElSuelo) // Verifica si se presion� la tecla de espacio y si el objeto est� en el suelo
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * salto, ForceMode.Impulse); // Aplica una fuerza de salto al objeto
            enElSuelo = false; // Indica que el objeto no est� en el suelo
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // Verifica si el objeto colision� con el suelo
        {
            enElSuelo = true; // Indica que el objeto est� en el suelo
        }
    }
}
