using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataPersistence : MonoBehaviour
{
    public static DataPersistence Instance;
    public string PlayerRecordName;
    public string PlayerName;
    public int Record;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadDatas();
    }

    [System.Serializable] // Importante.  JSon solo funciona con datos tagged como Serializables
    class SaveData //creamos una pequeña clase para los datos que queremos guardar
    {
        public string PlayerRecordName;
        public int Record;
    }
    public void SaveDatas()
    {
        SaveData data = new SaveData();
        
        data.PlayerRecordName = PlayerRecordName;
        data.Record = Record;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json); // requiere del namespace using System.IO;
        // en esta última linea creamos la carpeta donde se guardará el json
    }

    public void LoadDatas()  // llamamos a este metodo en el awake
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            PlayerRecordName = data.PlayerRecordName;
            Record = data.Record;
        }
    }

}
