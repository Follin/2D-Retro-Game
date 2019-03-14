using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public string[] usernames;
    public List<PlayerInfo> playerInfo = new List<PlayerInfo>();
    public PlayerInfo testStruct = new PlayerInfo();

    //  public Dictionary<string, Dictionary<string, int>> playerScores; 
    //public List<PlayerTeam> playerTeams;

}

[System.Serializable]
public struct PlayerInfo
{
    public string username;
    public string scoretype;
    public string rank;
    public int currentScore;
    public int currentRank;

}

[System.Serializable]
public struct PlayerInfoCollection
{
    public LinkedList<PlayerInfo> playerInfo;
}
