using System.Collections.Generic;

/**
 * A client have client_id, playTS, diffSongNum, and newSongid.
 */

class Client
{
    //keep to different song in hash set(song id: Identifier of a song that a client played)
    private HashSet<string> songid = new HashSet<string>();
    //Identifier of a client
    private string clientid;
    //date time of the client playing a song
    private string playTS;
    //different song number
    private int diffSongNum;
    //newly added song
    private string newSongid;

    //Default Constructor
    public Client() { diffSongNum = 0; }

    // three parameter construcotr
    public Client(string s, string cl, string pts)
    {
        Songid.Add(s);
        NewSongid = s;
        Clientid = cl;
        PlayTS = pts;
    }

    public string Clientid { get => clientid; set => clientid = value; }
    public string PlayTS { get => playTS; set => playTS = value; }
    public HashSet<string> Songid { get => songid; set => songid = value; }
    public string NewSongid { get => newSongid; set => newSongid = value; }

    // if it'is district, add song id.
    public bool add(string s_id)
    {
        return Songid.Add(s_id);
        
    }
    // size distinct song
    public int sizeSong()
    {
        return songid.Count;
    }
}

