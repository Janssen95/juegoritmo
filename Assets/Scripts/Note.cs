using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Note : MonoBehaviour
{
    public float judge; //Linea juez
    private float upperTolerance; //Tolerancia de la linea superior
    private float lowerTolerance; //Tolerancia de la linea inferior
    public float tolerance; //Valor de tolerancia
    private int score;
    private Text scoreBoard;
    private AudioSource hit; //sonidito
    private Vector2 removePos; //Posicion en que se borra
    private Vector2 spawnPos; //Posicion en que aparece
    private float spawnTime; //beat en el que aparece la nota
    public float distance; //Distancia a recorrer
    public float approachRate; //Velocidad de movimiento

    void Start()
    {
        //Calcular tolerancias
        upperTolerance = judge + tolerance;
        lowerTolerance = judge - tolerance;

        //posiciones de inicio de las notas y distancia a recorrer para lerp
        removePos = new Vector2(transform.position.x, lowerTolerance - 1);
        distance = Vector2.Distance(spawnPos, removePos);

        //tiempo de aparicion para calculos del lerp
        spawnTime = (float)AudioSettings.dspTime;


        //Sonidito cuando le das
        hit = GameObject.Find("hit").GetComponent<AudioSource>();
        scoreBoard = GameObject.Find("scoreBoard").GetComponent<Text>();

    }


    void Update()
    {
        inputKeyboard();
        deleteNote();
        movement();
    }


    void movement() /*Mover las notas en el eje y a lo largo del carril*/
    {
        spawnPos = transform.position;
        transform.position = Vector2.MoveTowards(spawnPos, removePos, approachRate * Time.deltaTime);
    }


    void judging()
    {
        //Compara la posicion de la nota con respecto a la posicion de la linea juez para determinar si le diste bien
        if (transform.position.y >= lowerTolerance && transform.position.y <= upperTolerance)
        {
            hit.Play();
            Destroy(gameObject);
            
        }
    }


    void deleteNote() //Eliminar notas conforme se salgan del area de juego
    {
        if (transform.position.y < lowerTolerance - 1)
        {
            Destroy(gameObject);
        }
    }


    void inputCheck() //Recibir input del usuario, ver si le pego a la nota y llamar funcion de juez
    {
        if (Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    judging();
                }
            }
        }
    }

    void inputKeyboard()
    {
        if (Input.anyKey)
        {
            judging();
        }
    }
}
