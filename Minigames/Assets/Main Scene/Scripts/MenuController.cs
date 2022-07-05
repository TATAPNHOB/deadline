using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement; 
using UnityEngine.Audio;

public class MenuController : MonoBehaviour
{
    
    public bool isPauseMenu;
    public bool isOpened = false; //������� �� ����
    public float volume = 0; //���������
    //public int quality = 0; //��������
    public bool isFullscreen = false; //������������� �����
    public AudioMixer audioMixer; //��������� ���������
    public Dropdown resolutionDropdown; //������ � ������������ ��� ����
    private Resolution[] resolutions; //������ ��������� ����������
    private int currResolutionIndex = 0; //������� ����������

    public GameObject Settings;
    public GameObject Buttons;
    public GameObject Menu;
    public GameObject Canvas;
    public GameObject otherMenu;
    public GameObject result_label;
    public GameObject Label_Timer;

    private void Awake()
    {
        if (GameObject.FindGameObjectsWithTag("PauseMenu").Length>1)
        {
            Destroy(GameObject.FindGameObjectsWithTag("PauseMenu")[0]);
        }
    }

    public void OpenClose_Menu() 
    {
        isOpened = !isOpened;
        Menu.SetActive(isOpened);
    }

    public void ToHubRelocate ()
    {
        /*GameObject[] timer_labels = GameObject.FindGameObjectsWithTag("Timer");*/

        Label_Timer.SetActive(true);
        result_label.SetActive(true);

        Object.Destroy(this.gameObject);
        
        SceneManager.LoadScene("Hub");
        /*if (isPauseMenu) { DontDestroyOnLoad(GetComponent<Canvas>()); }*/
    }


    // Start is called before the first frame update
    void Start()
    {
        if (isPauseMenu) { DontDestroyOnLoad(Canvas); }
        Menu.SetActive(isOpened);
        Settings.SetActive(false);
        GameObject[] timerObjects = GameObject.FindGameObjectsWithTag("Timer");
        foreach (var iterObject in timerObjects)
        {
            iterObject.SetActive(false);
        }
        resolutionDropdown.ClearOptions(); //�������� ������ �������
        resolutions = Screen.resolutions; //��������� ��������� ����������
        List<string> options = new List<string>(); //�������� ������ �� ���������� ����������
            
        for (int i = 0; i < resolutions.Length; i++) //���������� ������ � ������ �����������
        {
            string option = resolutions[i].width + " x " + resolutions[i].height; //�������� ������ ��� ������
            options.Add(option); //���������� ������ � ������

            if (resolutions[i].Equals(Screen.currentResolution)) //���� ������� ���������� ����� ������������
            {
                currResolutionIndex = i; //�� ���������� ��� ������
            }
        }

        resolutionDropdown.AddOptions(options); //���������� ��������� � ���������� ������
        resolutionDropdown.value = currResolutionIndex; //��������� ������ � ������� �����������
        resolutionDropdown.RefreshShownValue(); //���������� ������������� ��������


    }

    // Update is called once per frame
    void Update()
    {
        if (isPauseMenu && Input.GetKeyDown(KeyCode.Escape))
        {
            Settings.SetActive(false);
            Buttons.SetActive(true);
            OpenClose_Menu();

        }
    }

    public void ChangeVolume(float val) //��������� �����
    {
        volume = val;
    }

    public void ChangeResolution() //��������� ����������
    {

        
        currResolutionIndex = resolutionDropdown.value;
        Debug.Log(currResolutionIndex);
    }

    public void ChangeFullscreenMode() //��������� ��� ���������� �������������� ������
    {
        isFullscreen = !isFullscreen;
    }

    /*public void ChangeQuality(int index) //��������� ��������
    {
        quality = index;
    }*/

    public void Open_Settings_Menu()
    {
        Settings.SetActive(true);
        Buttons.SetActive(false);

    }

    public void SaveSettings()
    {
        //audioMixer.SetFloat("MasterVolume", volume); //��������� ������ ���������
        //  QualitySettings.SetQualityLevel(quality); //��������� ��������
        Screen.fullScreen = isFullscreen; //��������� ��� ���������� �������������� ������
        Screen.SetResolution(Screen.resolutions[currResolutionIndex].width, Screen.resolutions[currResolutionIndex].height, isFullscreen); //��������� ����������
        Close_Settings_Menu();
    }

    public void Close_Settings_Menu()
    {
        Settings.SetActive(false);
        Buttons.SetActive(true);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Main Scene"); //������� �� ����� � ��������� Menu
    }


    public void Exit_Game()
    {
        Application.Quit();
    }



}
