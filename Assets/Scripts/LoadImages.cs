using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class LoadImages : MonoBehaviour 
{
	[SerializeField] private RawImage rawImage;
	private ArrayList imageBuffer = new ArrayList();
	private string fullFileName;
	private string pathImageAssets;
	private string pathPrefix;
	private string[] dirsPNG;
	private string[] dirsJPG;
	private int imageIndex = 0;
	private Texture defaultTexture; 
	private bool noImages = false;
	private bool activeOnce = false;

	private void Start()
	{
		Initialize();
	}

	private void Initialize()
	{
		pathPrefix = @"file://";
		pathImageAssets = @"C:\Users\" + System.Environment.UserName + @"\Pictures\";
		dirsPNG = Directory.GetFiles( @pathImageAssets,"*.png",SearchOption.AllDirectories);
		dirsJPG = Directory.GetFiles( @pathImageAssets,"*.jpg",SearchOption.AllDirectories);
		if(dirsPNG.Length == 0 && dirsJPG.Length == 0)
			noImages = true;
		if(dirsJPG.Length >= dirsPNG.Length)
		{
			StartCoroutine(LoadJPG(0.01f));
			StartCoroutine(LoadPNG(0.1f));
		}
		else
		{
			StartCoroutine(LoadPNG(0.01f));
			StartCoroutine(LoadJPG(0.1f));
		}
	}

	private IEnumerator LoadPNG(float waitTime)
	{
		yield return new WaitForSeconds(waitTime);
			LoadImagePNG();
	}

	private IEnumerator LoadJPG(float waitTime)
	{
		yield return new WaitForSeconds(waitTime);
			LoadImageJPG();
	}
	
	private void LoadImagePNG()
	{	
		fullFileName = pathPrefix + dirsPNG[imageIndex];
		WWW www = new WWW(fullFileName);
		Texture2D texTmp = new Texture2D(1920,1080,TextureFormat.DXT5,false);
		www.LoadImageIntoTexture(texTmp);
		imageBuffer.Add(texTmp);
		if(www.isDone && !activeOnce)
		{
			rawImage.texture = (Texture2D)imageBuffer[0];
		}
	}

	private void LoadImageJPG()
	{
		fullFileName = pathPrefix + dirsJPG[imageIndex];
		WWW www = new WWW(fullFileName);
		Texture2D texTmp = new Texture2D(1920,1080,TextureFormat.DXT1,false);
		www.LoadImageIntoTexture(texTmp);
		imageBuffer.Add(texTmp);
		if(www.isDone)
		{
			rawImage.texture = (Texture2D)imageBuffer[0];
		}
	}
}