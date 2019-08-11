using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneTimer : MonoBehaviour
{
    public AudioSource asrc;
    GameController gc;
    // Start is called before the first frame update
    void Start()
    {
        gc = GetComponent<GameController>();

        ApplicationModel.cutscene = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!asrc.isPlaying)
        {
            Debug.Log("Cutscene ended");
            gc.NextScene();
        }
    }
}
