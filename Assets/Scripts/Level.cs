using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class Level : MonoBehaviour
{
    public float bpm;
    public bool movingState;
    public List<KeyTrack> keyTracks = new List<KeyTrack>();
    
    // The index range of the tracks. By default from -1 to 1.
    // These corresponds to the y-value of the track gameObjects.
    public int mTrackRangeMin;
    public int mTrackRangeMax;
}
