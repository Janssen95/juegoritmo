using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Note : MonoBehaviour
{

    public float approachRate;
    private Vector2 position;
    public float judge;
    private float upperTolerance;
    private float lowerTolerance;
    public float tolerance;
    private int score;
    private float touchY;
    private Text scoreBoard;
    private AudioSource hit;
    public Vector2 spawnPos;
    public Vector2 removePos;
    public float songPosInBeats;

    void Start()
    {
        //Calcular tolerancias
        upperTolerance = judge + tolerance;
        lowerTolerance = judge - tolerance;
        spawnPos.x = position.x;
        spawnPos.y = 7;
        removePos.y = lowerTolerance - 1;
        removePos.x = position.x;
        //Sonidito cuando le das
        hit = GameObject.Find("hit").GetComponent<AudioSource>();
        scoreBoard = GameObject.Find("scoreBoard").GetComponent<Text>();

    }


    void Update()
    {

        inputCheck();
        deleteNote();
        movement();
    }


    void movement() /*Mover las notas en el eje y a lo largo del carril*/
    {
        transform.position = Vector2.Lerp(spawnPos, removePos, songPosInBeats);
        position.y = position.y + approachRate;
        gameObject.transform.position = position;
    }


    void judging()
    {
        //Compara la posicion de la nota con respecto a la posicion de la linea juez para determinar si le diste bien
        if (position.y >= lowerTolerance && position.y <= upperTolerance)
        {
            hit.Play();
            Destroy(gameObject);
            score = score + 1;
            
        }
    }


    void deleteNote() //Eliminar notas conforme se salgan del area de juego
    {
        if (position.y < removePos.y)
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
}
