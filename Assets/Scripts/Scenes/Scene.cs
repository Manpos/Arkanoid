using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Scene : MonoBehaviour
{
    protected Scene _nextScene;
    protected Scene _previousScene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public abstract void LoadScene();
    public abstract void UnloadScene();
}
