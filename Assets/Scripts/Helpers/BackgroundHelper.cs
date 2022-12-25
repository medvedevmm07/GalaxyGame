using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundHelper : MonoBehaviour
{
    public Renderer backgroundRenderer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(backgroundRenderer != null) {
            backgroundRenderer.material.mainTextureOffset = new Vector2(0f, 0.1f * Time.time); 
        }
    }
}
