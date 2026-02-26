using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2
{
    public class MeetingWithoutEndTime : Meeting
    {
        public MeetingWithoutEndTime(DateTime dateStart) : base(dateStart, DateTime.MaxValue) { }
    }
}
