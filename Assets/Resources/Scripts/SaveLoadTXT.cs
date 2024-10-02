using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveLoadTXT : MonoBehaviour
{
    public string fileName = "test.txt";
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
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
        // Guardar
        StreamWriter streamWriter = new StreamWriter(Application.persistentDataPath + '\\' + fileName);
        streamWriter.WriteLine("Archivo de guardado");
        streamWriter.WriteLine(Random.Range(0, 100));
        streamWriter.WriteLine(transform.position.x);
        streamWriter.WriteLine(transform.position.y);
        streamWriter.WriteLine(transform.position.z);

        streamWriter.Close(); //Importante cerrar
    }

    private void Load()
    {
        // Cargar informacion
        if (File.Exists(Application.persistentDataPath + '\\' + fileName))
        {
            try
            {
                StreamReader streamReader = new StreamReader(Application.persistentDataPath + '\\' + fileName);
                streamReader.ReadLine(); //La primera linea aqui no es importante, movemos el cursor del archivo a la siguiente linea
                streamReader.ReadLine();
                float x = float.Parse(streamReader.ReadLine());
                float y = float.Parse(streamReader.ReadLine());
                float z = float.Parse(streamReader.ReadLine());

                streamReader.Close();

                transform.position = new Vector3(x, y, z); //Establecemos la posicion de GameObject
            }
            catch (System.Exception e) //Como no guardamos la info en ningun servidor sino en local, no tenemos control sobre los archivos del usuario, nos aseguramos de que si algo va mal este todo controlado
            {
                //O sacar al topo del animal crossing
                Debug.Log(e.Message);
            }
        }
    }
}