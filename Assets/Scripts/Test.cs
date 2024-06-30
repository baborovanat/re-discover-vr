//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
////using UnityGoogleDrive;
//using UnityEngine.UI;

//public class Test : MonoBehaviour
//{
//    // Start is called before the first frame update
//    public Texture2D image;
//    public RawImage finaldownloaded;
//    public byte[] Downloadedcontent;

//    // Update is called once per frame
//    void Update()
//    {
//        if (Input.GetKeyDown(KeyCode.U))
//        {
//            StartCoroutine("Test004_FilesCreate");
//        }
//        if (Input.GetKeyDown(KeyCode.D))
//        {
//            StartCoroutine("Test006_FilesDownload");
//        }

//    }
//    public IEnumerator Test004_FilesCreate()
//    {
//        var content = image.EncodeToPNG();
//        var file = new UnityGoogleDrive.Data.File() { Name = "AutoTestUpload", Content = content };
//        var request = GoogleDriveFiles.Create(file);
//        request.Fields = new List<string> { "id" };
//        yield return request.Send();
//        print(request.IsError);
//        print(request.ResponseData.Content);
//        print(request.ResponseData.Id);
//    }

//    public IEnumerator Test006_FilesDownload()
//    {
//        var request = GoogleDriveFiles.Download("");
//        yield return request.Send();
//        print(request.IsError);
//        print(request.ResponseData.Content);
//        Downloadedcontent = request.ResponseData.Content;
//        Texture2D tex = new Texture2D(1024, 1024);
//        tex.LoadImage(Downloadedcontent);
//        tex.Apply();
//        finaldownloaded.texture = tex;
//    }
//}
