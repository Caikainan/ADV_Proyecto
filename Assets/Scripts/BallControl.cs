using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    public float velocidad = 10f; // Velocidad de movimiento del objeto
    public float salto = 10f; // Fuerza del salto
    public float limiteIzquierdo = -5f; // Límite izquierdo del movimiento
    public float limiteDerecho = 5f; // Límite derecho del movimiento

    bool enElSuelo = true; // Indica si el objeto está en el suelo

    void Update()
    {
        float movimientoHorizontal = Input.GetAxis("Horizontal"); // Obtiene la entrada del teclado en el eje horizontal
        float movimientoVertical = Input.GetAxis("Vertical"); // Obtiene la entrada del teclado en el eje vertical

        Vector3 movimiento = new Vector3(movimientoHorizontal, 0f, movimientoVertical); // Combina los movimientos horizontal y vertical

        transform.Translate(movimiento * velocidad * Time.deltaTime); // Mueve el objeto en ambos ejes

        // Limita el movimiento del objeto dentro de los límites establecidos
        float posicionX = Mathf.Clamp(transform.position.x, limiteIzquierdo, limiteDerecho);
        transform.position = new Vector3(posicionX, transform.position.y, transform.position.z);

        if (Input.GetKeyDown(KeyCode.Space) && enElSuelo) // Verifica si se presionó la tecla de espacio y si el objeto está en el suelo
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * salto, ForceMode.Impulse); // Aplica una fuerza de salto al objeto
            enElSuelo = false; // Indica que el objeto no está en el suelo
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // Verifica si el objeto colisionó con el suelo
        {
            enElSuelo = true; // Indica que el objeto está en el suelo
        }
    }
}
