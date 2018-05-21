using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carril1S : MonoBehaviour
{
    private float[] notes; //mantiene todas las posiciones en beats de las notas de la cancion (arreglo)
    private int nextIndex = 0; //index de la siguiente nota que aparecera
    public Transform note;
    private double Arrival;


    void Start()
    {
        notes = new float[8];
        NoteNumbering();
    }


    void Update()
    {
        Arrival = GameObject.Find("Masquerade").GetComponent<SongManager>().songPosInBeats; //Se consigue variable del song manager de llegada de las notas 

        if (nextIndex <= notes.Length && notes[nextIndex] <= Arrival) //Checa si quedan notas y si ya es momento de que salga otra
        {
            Instantiate(note, new Vector3(gameObject.transform.position.x, 10), Quaternion.identity); //Saca la nota sobre el carril
            nextIndex++;
        }
    }


    void NoteNumbering() //Tiempos de salida de cada nota, en beats
    {
        notes[0] = 5.5f;
        notes[1] = 7;
        notes[2] = 9;
        notes[3] = 11;
        notes[4] = 13f;
        notes[5] = 15;
        notes[6] = 17;
        notes[7] = 18.5f;
    }
}

