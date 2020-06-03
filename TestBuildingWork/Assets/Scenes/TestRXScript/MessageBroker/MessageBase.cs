using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
namespace MessageBase
{
    public class MessageBase
    {
        public MonoBehaviour sender { get; private set; } // MonoBehaviour отправителя
        public int id { get; private set; } // id сообщения
        public System.Object data { get; private set; } // данные

        public MessageBase(MonoBehaviour sender, int id, System.Object data)
        {
            this.sender = sender;
            this.id = id;
            this.data = data;
        }

        public static MessageBase Create(MonoBehaviour sender,
            int id, System.Object data)
        {
            return new MessageBase(sender, id, data);
        }
    }
    public class ServiceShareData
    {
        public const int MSG_ATTACK = 1001;
    }
}
