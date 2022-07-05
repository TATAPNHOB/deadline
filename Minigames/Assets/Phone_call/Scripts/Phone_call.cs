using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Phone_call : Minigame
{
    public Text Name_1,Name_2,Name_3,Name_4,Name_5,Name_6,Name_7,Name_8,Name_9,Name_10,Name_11,Name_12,Name_13,Name_14,Name_15;
    public Text Calling_number;
    public Text Calling_name;
    string calling_num;//Правильный номер
    int num_len;
    string player_calling_num;//Номер, который набирает игрок
    
    float start_time;
    int waitTime;
    int diff = 3;
    public Text res_lbl;
    void Start()
    {
        string [] names = new string[]{"Морозов Матвей","Сахарова Мария","Владимирова Полина","Щербаков Роман","Федосеева Мария","Смирнова Диана","Карасев Михаил","Лебедева Злата","Журавлев Лев","Захаров Евгений","Яковлев Лука","Козлова Алина","Селиванов Лев","Митрофанова Алина","Макаров Иван"};
        int [] numbers = new int[15];
        for(int i = 0;i<numbers.Length;i++)
        {
            numbers[i] = Random.Range(1000000,9999999);
        }
        
        Text[] stroki = new Text[] {Name_1,Name_2,Name_3,Name_4,Name_5,Name_6,Name_7,Name_8,Name_9,Name_10,Name_11,Name_12,Name_13,Name_14,Name_15,};
        for (int i = names.Length - 1; i >= 1; i--)
        {
        int j = Random.Range(0,i + 1);
        string tmp = names[j];
        names[j] = names[i];
        names[i] = tmp;
        }
        for(int i = 0;i<names.Length;i++)
        {
            stroki[i].text=names[i]+" "+numbers[i].ToString();
        }
        int calling_ind = Random.Range(1,16);
        Calling_name.text = "Позвони "+names[calling_ind];
        calling_num = numbers[calling_ind].ToString();
        start_time=Time.time;
        switch(diff)
        {
            case 1:
                waitTime = 15;
                break;
            case 2:
                waitTime = 12;
                break;
            case 3:
                waitTime = 9;
                break;
        }
    }

    private void Update()
    {
        base.Update_MAIN();
    }
    public void num_click(int num)
    {
        if(num_len<7)
        {

            num_len++;
            player_calling_num+=num.ToString();
            Calling_number.text = player_calling_num;
            
        }
        

    }
    public void del_click()
    {
        if(num_len>0)
        {
            num_len--;
            string tmp = "";
            for(int i = 0;i<num_len;i++)
            {
                tmp+=player_calling_num[i];
            }
            player_calling_num=tmp;
            Calling_number.text=player_calling_num;
        }
        
    }
    public void call_btn_click()
    {
        float playerTime = Time.time;
        float error = playerTime-start_time;
        if(error>waitTime)
        {
            res_lbl.text = "Поздно";
        }
        else
        {
            if(calling_num!=player_calling_num)
            {
                res_lbl.text = "Ошибка";
            }
            else
            {
                res_lbl.text = "Молодец";
            }
        }
    }
    
    
    

    
    
}
