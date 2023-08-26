using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DifficultyType
{
    Easy,
    Hard
}

[CreateAssetMenu(fileName = "Song Data", menuName = "Song Data", order = 1)]

public class SongData : ScriptableObject
{
    [SerializeField]
    public string SongName;
    public int Tempo;
    public string Composer;
    public DifficultyType Difficulty;
}
