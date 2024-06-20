using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;

public class DBManager : MonoBehaviour
{
    private static DBManager _instance;
    public static DBManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<DBManager>();
                DontDestroyOnLoad(_instance);
            }
            return _instance;
        }
    }

    public static IDbConnection dbconn;

    void Awake()
    {
        string conn = "URI=file:" + Application.dataPath + "/Plugins/LevelsDatabase.db";
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open();

        CreateTable();
    }

    public void CreateTable()
    {
        IDbCommand dbcmd = dbconn.CreateCommand();
        string query = "CREATE TABLE IF NOT EXISTS 'GameData' ('Id'INTEGER NOT NULL UNIQUE, 'GameName'  INTEGER NOT NULL UNIQUE, 'Time'  INTEGER NOT NULL, 'Deaths' INTEGER NOT NULL, 'CheckPoint'    INTEGER NOT NULL, 'TakenKeys' INTEGER NOT NULL, PRIMARY KEY(Id));";

        dbcmd.CommandText = query;
        dbcmd.ExecuteNonQuery();
    }

    public void SaveData(string gameName, int time, int deaths, int checkPoint, string takenkeys)
    {
        IDbCommand dbcmd = dbconn.CreateCommand();
        string query = "INSERT INTO GameData (GameName, Time, Deaths, CheckPoint, TakenKeys) VALUES ('"+gameName+"'," + time + "," + deaths + "," + checkPoint + ",'" + takenkeys + "')";

        dbcmd.CommandText = query;
        dbcmd.ExecuteNonQuery();
    }

    public int CountData()
    {
        IDbCommand dbcmd = dbconn.CreateCommand();
        string query = "SELECT count(*) FROM GameData";

        int count = 0;

        dbcmd.CommandText = query;
        IDataReader reader = dbcmd.ExecuteReader();

        while (reader.Read())
        {
            count = reader.GetInt32(0);
        }

        return count;
    }
    
    public int GetIntByName(string s, string gameName)
    {
        IDbCommand dbcmd = dbconn.CreateCommand();
        string query = "SELECT " + s + " FROM GameData where GameName = '" + gameName + "'";

        dbcmd.CommandText = query;
        IDataReader reader = dbcmd.ExecuteReader();

        int data = 0;

        while (reader.Read())
        {
            data = reader.GetInt32(0);
        }
        return data;
    }

    public string GetStringByName(string s, string gameName)
    {
        IDbCommand dbcmd = dbconn.CreateCommand();
        string query = "SELECT " + s + " FROM GameData where GameName = '" + gameName + "'";

        dbcmd.CommandText = query;
        IDataReader reader = dbcmd.ExecuteReader();

        string data = "";

        while (reader.Read())
        {
            data = reader.GetString(0);
        }
        return data;
    }

    public string GetStringByName(string s, int i)
    {
        IDbCommand dbcmd = dbconn.CreateCommand();
        string query = "SELECT " + s + " FROM GameData where Id = " + i + "";

        dbcmd.CommandText = query;
        IDataReader reader = dbcmd.ExecuteReader();

        string data = "";

        while (reader.Read())
        {
            data = reader.GetString(0);
        }
        return data;
    }

    public void UpdateData(string gameName, int time, int deaths, int checkPoint, string takenkeys)
    {
        IDbCommand dbcmd = dbconn.CreateCommand();
        string query = "UPDATE GameData SET Time = "+time+", Deaths = " +deaths+", CheckPoint = "+checkPoint+", TakenKeys = '"+takenkeys+"' WHERE GameName = '"+gameName+"'";

        dbcmd.CommandText = query;
        dbcmd.ExecuteNonQuery();
    }

    public void DeleteData(string gameName)
    {
        IDbCommand dbcmd = dbconn.CreateCommand();
        string query = "DELETE FROM GameData WHERE GameName = '"+gameName+"'";

        dbcmd.CommandText = query;
        dbcmd.ExecuteNonQuery();
    }

    public bool FindExistingData(string toFind, string column)
    {
        IDbCommand dbcmd = dbconn.CreateCommand();
        bool found = false;

        for (int i = 1; i <= CountData(); i++)
        {
            if (GetStringByName(column, i) == toFind)
            {
                found = true;
            }
        }
        return found;
    }

    public void CloseDB()
    {
        dbconn.Close();
    }
}

