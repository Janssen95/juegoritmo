using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carril4S : MonoBehaviour
{
    private float[] notes; //mantiene todas las posiciones en beats de las notas de la cancion (arreglo)
    private int nextIndex = 0; //index de la siguiente nota que aparecera
    public Transform note;
    private double Arrival;


    void Start()
    {
        notes = new float[100];
        NoteNumbering();
    }


    void Update()
    {
        Arrival = GameObject.Find("Masquerade").GetComponent<SongManager>().songPosInBeats; //Se consigue variable del song manager de llegada de las notas 

        if (nextIndex <= notes.Length && notes[nextIndex] <= Arrival) //Checa si quedan notas y si ya es momento de que salga otra
        {
            Instantiate(note, new Vector3(gameObject.transform.position.x, 10), Quaternion.identity); //Saca la nota
            nextIndex++;
        }
    }


    void NoteNumbering() //Tiempos de salida de cada nota, en beats
    {
        notes[0] = 6f;
        notes[1] = 7f;
        notes[2] = 9f;
        notes[3] = 11f;
        notes[4] = 13;
        notes[5] = 15;
        notes[6] = 16.5f;
        notes[7] = 19;
    }
}

