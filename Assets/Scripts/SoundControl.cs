using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControl : MonoBehaviour
{
    // Start is called before the first frame update
    public void SoundOff()
    {
        AudioListener.volume = 0f;
    }

    public void SoundOn()
    {
        AudioListener.volume = 1f;
    }
}
