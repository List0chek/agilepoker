using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2
{
    public class MeetingWithType : Meeting
    {
        public enum MeetingType
        {
            Conference,

            Assignment,

            Call,

            BirthDay
        }

        public MeetingType Type { get; }

        public MeetingWithType(DateTime dateStart, DateTime dateEnd, MeetingType typeMeeting) : base(dateStart, dateEnd)
        {
            this.Type = typeMeeting;
        }
    }
}
