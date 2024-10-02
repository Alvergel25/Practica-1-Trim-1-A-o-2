using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]

struct PlayerData
{
    public Vector3 position;
    public Vector3 score;
    public Vector3 hour;
}
public class SaveLoadJson : MonoBehaviour
{
    public string fileName = "SaveFile.json";
    // Start is called before the first frame update
    void Start()
    {
        fileName = Application.persistentDataPath + "\\" + fileName;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.G))
        {
            Save();
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            Load();
        }
    }

    private void Save()
    {
        StreamWriter streamWriter = new StreamWriter(fileName);

        PlayerData playerData = new PlayerData();
        playerData.position = transform.position;

        string json = JsonUtility.ToJson(playerData);
        streamWriter.Write(json);

        streamWriter.Close();
    }

    private void Load()
    {
        if(File.Exists(fileName))
        {
            StreamReader streamReader = new StreamReader(fileName);

            string json = streamReader.ReadToEnd();
            streamReader.Close();

            try
            {
                PlayerData playerData = JsonUtility.FromJson<PlayerData>(json);
                transform.position = playerData.position;
            }
            catch(System.Exception e)
            {
                Debug.Log(e.Message);
            }
        }
    }
}
