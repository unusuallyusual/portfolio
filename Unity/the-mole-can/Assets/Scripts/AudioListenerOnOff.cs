using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioListenerOnOff : MonoBehaviour
{
    public void SoundOff()
    {
        AudioListener.volume = 0;
    }
    public void SoundOn()
    {
        AudioListener.volume = 1;
    }
}
