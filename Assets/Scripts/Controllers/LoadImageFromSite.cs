using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.Networking;
public class LoadImageFromSite
{
    private static string siteURL = "https://picsum.photos/seed";
    private static int imageHeight = 536;
    private static int imageWidth = 354;
    private static Sprite defaultImage;

    public static IEnumerator LoadImageForCard(Card card)
    {
        UnityWebRequest webRequest = UnityWebRequestTexture.GetTexture(GetURLRequest());
        yield return webRequest.SendWebRequest();
        if ( webRequest.isNetworkError || webRequest.isHttpError)
        {
            Debug.LogError(webRequest.error);
            card.cardImage = defaultImage;
        }
        else
        {
            Texture2D texture = DownloadHandlerTexture.GetContent(webRequest);
            card.cardImage = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
        }
    }


    private static string GetURLRequest()
    {
        return siteURL + "/" + GenerateSeed() + "/" + imageHeight.ToString() + "/" + imageWidth.ToString();
    }

    private static int GenerateSeed()
    {
        return Random.Range(0, 100000);
    }
}
