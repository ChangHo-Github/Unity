using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NativeGalleryExample : MonoBehaviour
{
    private Texture2D texture;

    private void SaveToGalleryImage()
    {
        texture.name = "";
        NativeGallery.SaveImageToGallery(texture, "FolderName", texture.name, (success, path) =>
        {

            if (success)
            {
                // ������ �����������
            }
            else
            {
                // ������ ���?
            }

        });
    }

    private void LoadToGalleryImage()
    {
        NativeGallery.Permission permission = NativeGallery.GetImageFromGallery((path) =>
        {

            if (path != null)
            {

                texture = NativeGallery.LoadImageAtPath(path);

                if (texture == null)
                {
                    return;
                }
                else
                {

                    string[] split = path.Split('/');
                    texture.name = split[split.Length - 1];
                }

            }

        });
    }
}
