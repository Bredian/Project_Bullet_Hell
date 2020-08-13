using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveHighScore 
{
    public static void SaveScore()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/highscore.hsc";
        FileStream stream = new FileStream(path, FileMode.Create);

        HIghscore hIghscore = new HIghscore();

        formatter.Serialize(stream, hIghscore);
        stream.Close();
    }

    public static int LoadScore()
    {
        string path = Application.persistentDataPath + "/highscore.hsc";
        
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            HIghscore hIghscore = formatter.Deserialize(stream) as HIghscore;
            stream.Close();
            return hIghscore.highScore;
        }
        else
        {
            Debug.Log("Save file does not found");

            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Create);

            HIghscore hIghscore = new HIghscore();
            hIghscore.highScore = 0;
            formatter.Serialize(stream, hIghscore);
            stream.Close();
            return hIghscore.highScore;
        }
    }
}
