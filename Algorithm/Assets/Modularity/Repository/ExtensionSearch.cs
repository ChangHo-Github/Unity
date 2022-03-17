using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class ExtensionSearch : MonoBehaviour
{
    void Start()
    {
        string directoryPath = Application.persistentDataPath + "/" + "MyPicture";
        DirectoryInfo directoryInfo = new DirectoryInfo(directoryPath);
        if (!directoryInfo.Exists)
        {
            directoryInfo.Create();
        }

        string[] extensions = new[] { ".jpg", ".jpeg", ".png", ".JPG", ".JPEG", ".PNG" };
        FileInfo[] image = directoryInfo.GetFiles().Where(e => extensions.Contains(e.Extension.ToLower())).ToArray();
        FileInfo[] imageArray = image.Union(image).OrderByDescending(o => o.CreationTime).ToArray();

        if(imageArray.Length == 0)
        {
            return;
        }
        else
        {

        }
    }
}
