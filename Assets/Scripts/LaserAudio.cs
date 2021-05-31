using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserAudio : MonoBehaviour
{
    private float _audioVolume;
    private bool _audioVolumeEquals1;
    private float _volumeChangingSpeed;

    private static int _laserAmount;

    public static int LaserAmount
    {
        get { return _laserAmount; }
        set { _laserAmount = value; }
    }

    private AudioSource _audioSource;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        LaserAmount = 0;
        _volumeChangingSpeed = 2.0f;
        _audioVolumeEquals1 = false;
    }

    void Update()
    {
        if (PlayerPrefs.GetString("Music") != "no")
        {
            if (LaserAmount == 0)
            {
                _audioVolume = Mathf.Max(_audioVolume - _volumeChangingSpeed * Time.deltaTime, 0.0f);
            }
            else if (LaserAmount == 1)
            {
                if (_audioVolumeEquals1 == false)
                {
                    _audioVolume = Mathf.Min(_audioVolume + _volumeChangingSpeed * Time.deltaTime, 0.4f);
                }
                else if (_audioVolumeEquals1)
                {
                    _audioVolume = Mathf.Max(_audioVolume - _volumeChangingSpeed * Time.deltaTime, 0.4f);
                }
            }
            else if (LaserAmount == 2)
            {
                _audioVolume = Mathf.Min(_audioVolume + _volumeChangingSpeed * Time.deltaTime, 0.6f);
            }
        }

        _audioSource.volume = _audioVolume;

        if (_audioVolume == 0.0f)
        {
            _audioVolumeEquals1 = false;
        }
        else if (_audioVolume == 0.6f)
        {
            _audioVolumeEquals1 = true;
        }
    }
}
