using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement; 
using UnityEngine.Audio;

public class MenuController : MonoBehaviour
{
    
    public bool isPauseMenu;
    public bool isOpened = false; //Открыто ли меню
    public float volume = 0; //Громкость
    //public int quality = 0; //Качество
    public bool isFullscreen = false; //Полноэкранный режим
    public AudioMixer audioMixer; //Регулятор громкости
    public Dropdown resolutionDropdown; //Список с разрешениями для игры
    private Resolution[] resolutions; //Список доступных разрешений
    private int currResolutionIndex = 0; //Текущее разрешение

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
        resolutionDropdown.ClearOptions(); //Удаление старых пунктов
        resolutions = Screen.resolutions; //Получение доступных разрешений
        List<string> options = new List<string>(); //Создание списка со строковыми значениями
            
        for (int i = 0; i < resolutions.Length; i++) //Поочерёдная работа с каждым разрешением
        {
            string option = resolutions[i].width + " x " + resolutions[i].height; //Создание строки для списка
            options.Add(option); //Добавление строки в список

            if (resolutions[i].Equals(Screen.currentResolution)) //Если текущее разрешение равно проверяемому
            {
                currResolutionIndex = i; //То получается его индекс
            }
        }

        resolutionDropdown.AddOptions(options); //Добавление элементов в выпадающий список
        resolutionDropdown.value = currResolutionIndex; //Выделение пункта с текущим разрешением
        resolutionDropdown.RefreshShownValue(); //Обновление отображаемого значения


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

    public void ChangeVolume(float val) //Изменение звука
    {
        volume = val;
    }

    public void ChangeResolution() //Изменение разрешения
    {

        
        currResolutionIndex = resolutionDropdown.value;
        Debug.Log(currResolutionIndex);
    }

    public void ChangeFullscreenMode() //Включение или отключение полноэкранного режима
    {
        isFullscreen = !isFullscreen;
    }

    /*public void ChangeQuality(int index) //Изменение качества
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
        //audioMixer.SetFloat("MasterVolume", volume); //Изменение уровня громкости
        //  QualitySettings.SetQualityLevel(quality); //Изменение качества
        Screen.fullScreen = isFullscreen; //Включение или отключение полноэкранного режима
        Screen.SetResolution(Screen.resolutions[currResolutionIndex].width, Screen.resolutions[currResolutionIndex].height, isFullscreen); //Изменения разрешения
        Close_Settings_Menu();
    }

    public void Close_Settings_Menu()
    {
        Settings.SetActive(false);
        Buttons.SetActive(true);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Main Scene"); //Переход на сцену с названием Menu
    }


    public void Exit_Game()
    {
        Application.Quit();
    }



}
