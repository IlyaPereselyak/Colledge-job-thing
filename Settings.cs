using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Работа с интерфейсами
using UnityEngine.SceneManagement; //Работа со сценами
using UnityEngine.Audio; //Работа с аудио

public class Settings : MonoBehaviour
{
    public bool isOpened = false; //Открыто ли меню
    public float volume = 0; //Громкость
    public bool isFullscreen = false; //Полноэкранный режим
    public AudioMixer am; //Регулятор громкости
    Resolution[] rsl;//Список с разрешениями для игры
    List<string> resolutions;//Список доступных разрешений
    public Dropdown dropdown;//Текущее разрешение

    public void Awake()
    {
        resolutions = new List<string>();
        rsl = Screen.resolutions;
        foreach (var i in rsl)
        {
            resolutions.Add(i.width + "x" + i.height);
        }
        dropdown.ClearOptions();
        dropdown.AddOptions(resolutions);
    }
    public void FullScreenToggle()
    {
        isFullscreen = !isFullscreen;
        Screen.fullScreen = isFullscreen;
    }
    public void AudioVolume(float sliderValue)
    {
        am.SetFloat("masterVolume", sliderValue);
    }
    public void Resolution(int r)
    {
        Screen.SetResolution(rsl[r].width, rsl[r].height, isFullscreen);
    }
    public void Quality(int q)
    {
        QualitySettings.SetQualityLevel(q);
    }
}
