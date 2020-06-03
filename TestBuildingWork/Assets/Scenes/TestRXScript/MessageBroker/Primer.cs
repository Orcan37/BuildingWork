using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MessageBase;
using UniRx;

public class Primer : MonoBehaviour  // на этом примере можно иметь откуда угодно отправить сообщение на проверку
{
    public CompositeDisposable disposables;
    void OnEnable()
    {
        disposables = new CompositeDisposable();
        MessageBroker.Default
            .Receive<MessageBase.MessageBase>() // задаем тип MessageBase
            .Where(msg => msg.id == ServiceShareData.MSG_ATTACK)//фильтруем message по id
            .Subscribe(msg => { // подписываемся
            string data = (string)msg.data; // кастим данные в нужный формат
                                            // можем работать как и с sender-ом так и с данными
            Debug.Log("sender:" + msg.sender.name + " receiver:" + name + " data:" + data);
            }).AddTo(disposables);
    }
    void OnDisable() // автоматически отписывается после выключения прошграммы 
    {
        Debug.Log("disposables != null");

        // отписываемся
        if (disposables != null)
        {
            disposables.Dispose();
        }
    }
//    void Start()
//    {
//        MessageBroker.Default
//  .Publish(MessageBase.MessageBase.Create(
//      this, // sender MonoBehaviour
//      ServiceShareData.MSG_ATTACK, // message id
//      "attack!" // data System.Ojbect
//  ));

//        MessageBroker.Default
//.Publish(MessageBase.MessageBase.Create(
//  this, // sender MonoBehaviour
//  1001, // message id
//  "Go!" // data System.Ojbect
//));
//        MessageBroker.Default
//.Publish(MessageBase.MessageBase.Create(
//this, // sender MonoBehaviour
//1002, // message id
//"RUN!" // data System.Ojbect
//));
//        //OnEnable();
//        //if (disposables != null)
//        //{
//        //    Debug.Log("disposables != null");   //OnDisable();
//        //}
//    }

}
