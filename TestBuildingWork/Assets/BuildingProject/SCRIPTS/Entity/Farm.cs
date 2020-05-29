using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Farm : Building  // через ферму можно делать кузницу может быть алхимическую лабораторию 
{
    [Header("FARM")]
    public DateTime LastCollectionRes;
    public AudioClip collectRes;
    public GameObject ObjectAnimate; // Какие вещи мы будем анимировать лист 
    public float Ymax = 0.086f; // max на какое растояние будем поднимаеть 
    public float Ymin = 0;// min  на какое растояние будем поднимаеть
    public double GoVerhNa1Procent; // коэфициент
    public float GOVerh;
    // Data когда последний раз собирали урожай через SQL
    /////// ГЛАВНОЕ РЕСУРСЫ
    public float power = 10f;  // P сколько собирается в секунду
    public float countResMax = 50;// сколько может быть на с кладе
    public float countRes = 0;// сколько в данный момент на складе
    public float curTimer;
    public float Gold;  // какой материал собираем можно сделать через enum
    // какую вещь собираем - например кузница
    public GameObject collectResBtn;

    public override void OnMouseDown()
    {
        base.OnMouseDown();
      
    }
 
        public  override void Start()
    {
        /*
        строчка вытаскивания из таблицы  из SQLite все
        // if (LastCollectionRes  != null) /// тут строчка если в таблице было  
        /// если не нул то     TimeSpan Ot =   DateTime.Now - LastCollectionRes;
        /// int RaznicaTime = (int)(Ot.TotalSeconds) =≥  // сколько  секунд прошло
        /// curTimer = RaznicaTime   //  например если 1000 то  countRes = countResMax полюбому будет
        ///
         // LastCollectionRes = DateTime.Now; //  если нул
       */
        base.Start();
        collectResBtn = this.transform.Find("Canvas/CollectRes").gameObject;
         
        float deleniyКRes = 100 / countResMax; // Текщее в процентах
        float delenieHight = (Ymax + Ymin) / 100;

        GoVerhNa1Procent = deleniyКRes * delenieHight;
   

        collectResBtn.GetComponent<Button>().onClick.AddListener(() => collectResources());

    }


    private void FixedUpdate()  // 
    {


        if (countRes != countResMax && consractBild)
        {
            if (countRes < countResMax)
            {
                curTimer += Time.deltaTime;
                countRes = power * curTimer;
                GOVerh = (float)(countRes * GoVerhNa1Procent) - Ymin;
                ObjectAnimate.transform.localPosition = new Vector3(ObjectAnimate.transform.localPosition.x, GOVerh, ObjectAnimate.transform.localPosition.z);

                //  Debug.Log(ObjectAnimate.transform.localPosition.y + "ObjectAnimate.transform.position.y" + GOVerh);
                // тут толжно быть расчет насколько вверх поднялись фермерские угодья

            }
            else { countRes = countResMax; ObjectAnimate.transform.localPosition = new Vector3(ObjectAnimate.transform.localPosition.x, Ymax, ObjectAnimate.transform.localPosition.z); }
        }

        if(countRes > countResMax / 5)
        {
            collectResBtn.SetActive(true);
        }
        else { collectResBtn.SetActive(false); }


    }

    public override void collectResources()  // метод собирания ресурсов Ставим дату на сейчасное число выщитываем сколько сегунд прошло с предыдущей даты  = вычисляем и потом вычисляем секунды умножаем на  сколько собирается в секунду =≥ обнуляем ресурсы
    {
        float gold = countRes * curTimer;
        if (gold > countResMax) { MS.playerM.gold += countResMax; } else { MS.playerM.gold += gold; }

        //////   вытаскивать характеристику 

        curTimer = 0;
        countRes = 0;
        MS.uIM.audioSource.GetComponent<AudioSource>().PlayOneShot(collectRes);
    }

    /*
   public void collectResourcesSQL() // тока  не работает Толжен взаимодействоать с SQL
    {
        TimeSpan Ot =   DateTime.Now - LastCollectionRes; 
     LastCollectionRes = DateTime.Now; 

     int RaznicaTime = (int)(Ot.TotalSeconds); 

     int  gold = (int)( RaznicaTime * power ); 
     if (gold > 0)
     {
         if (gold > countResMax) { MS.playerM.gold += countResMax; } else { MS.playerM.gold += gold; }
     }

        //////   вытаскивать характеристику 

        curTimer = 0;
        countRes = 0;
        MS.uIM.audioSource.GetComponent<AudioSource>().PlayOneShot(collectRes);
    }

  */

}
