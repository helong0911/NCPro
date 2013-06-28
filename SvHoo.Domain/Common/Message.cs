using System;

namespace SvHoo.Domain.Common
{
    public class Message
    {
        private MessageType _type = MessageType.None;
        public MessageType Type
        {
            get
            {
                return this._type;
            }
            set
            {
                this._type = value;
            }
        }

        public string Text
        {
            get;
            set;
        }

        public string Code
        {
            get;
            set;
        }

        public object Data { get; set; }
    }
}
