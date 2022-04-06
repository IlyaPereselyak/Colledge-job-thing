using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //������ � ������������
using UnityEngine.SceneManagement; //������ �� �������
using UnityEngine.Audio; //������ � �����

public class Settings : MonoBehaviour
{
    public bool isOpened = false; //������� �� ����
    public float volume = 0; //���������
    public bool isFullscreen = false; //������������� �����
    public AudioMixer am; //��������� ���������
    Resolution[] rsl;//������ � ������������ ��� ����
    List<string> resolutions;//������ ��������� ����������
    public Dropdown dropdown;//������� ����������

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
