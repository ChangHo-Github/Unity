using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TXT : MonoBehaviour
{
    public void TXTWrite()
    {
        string message = "파일 테스트합니다.";

        string filePath = Application.persistentDataPath + "/" + "Test";
        DirectoryInfo directoryInfo = new DirectoryInfo(Path.GetDirectoryName(filePath));
        if(!directoryInfo.Exists)
        {
            directoryInfo.Create();
        }

        FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write);
        StreamWriter streamWriter = new StreamWriter(fileStream, System.Text.Encoding.UTF8);
        streamWriter.WriteLine(message);
        streamWriter.Close();
    }

    public void TXTRead()
    {
        string message = "";

        string filePath = Application.persistentDataPath + "/" + "Test";
        FileInfo fileInfo = new FileInfo(filePath);
        if(fileInfo.Exists)
        {
            StreamReader streamReader = new StreamReader(filePath);
            message = streamReader.ReadToEnd();
            streamReader.Close();

            Debug.Log(message);
        }
        else
        {
            Debug.Log("파일 읽기 실패");
        }
    }

    public void TXTDelete()
    {
        string filePath = Application.persistentDataPath + "/" + "Test";
        File.Delete(filePath);
    }
}
