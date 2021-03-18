using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDisplay : MonoBehaviour
{
    public Renderer texRenderer;

    public void DrawTexture(Texture2D texture)
    {
        texRenderer.sharedMaterial.mainTexture = texture;
        texRenderer.transform.localScale = new Vector3(texture.width, 1, texture.height);
    }
}
