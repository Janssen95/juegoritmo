using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SongManager : MonoBehaviour
{
    private float songStartdsp; //El momento en que la cancion empieza en terminos del dspTime
    private float songPosition; //Posicion actual de la cancion en segundos
    public float songPosInBeats; //Posicion actual de la cancion en beats
    private float secPerBeat; //Segundos que tarda cada beat
    private float beatsPerSample; //beats por sample
    private float beatsShownInAdvance; //Tiempo en beats que tarda en empezar la cancion
    private float bpm;
    public float offset;


    void Start()
    {
        bpm = 128;
        secPerBeat = 60f / bpm; //Segundos por beat
        AudioSource music = GetComponent<AudioSource>();
        songStartdsp = (float)AudioSettings.dspTime;
        music.PlayScheduled(songStartdsp + 2);
    }


    void Update()
    {
        //Calcular estas vainas
        songPosition = (float)(AudioSettings.dspTime - songStartdsp - 2 - offset);
        songPosInBeats = songPosition / secPerBeat;
    }
}

