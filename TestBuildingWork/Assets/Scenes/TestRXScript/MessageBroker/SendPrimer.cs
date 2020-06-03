using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class SendPrimer : MonoBehaviour
// на этом примере можно иметь откуда угодно отправить сообщение на проверку
{
    void Start()
    {
        MessageBroker.Default
  .Publish(MessageBase.MessageBase.Create(
      this, // sender MonoBehaviour
      1001, // message id
      "attack!" // data System.Ojbect
  ));

        MessageBroker.Default
.Publish(MessageBase.MessageBase.Create(
  this, // sender MonoBehaviour
  1001, // message id
  "Go!" // data System.Ojbect
));
        MessageBroker.Default
.Publish(MessageBase.MessageBase.Create(
this, // sender MonoBehaviour
1002, // message id
"RUN!" // data System.Ojbect
));
        //OnEnable();
        //if (disposables != null)
        //{
        //    Debug.Log("disposables != null");   //OnDisable();
        //}
    }
}
