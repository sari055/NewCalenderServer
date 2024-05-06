﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarApp.Repositories.Entities
{
    public class EventModel
    {
        public int CalendarId { get; set; }
        public string EventType { get; set; }
        public string HebrewDate { get; set; }
        public int UserId { get; set; }
        public string EventYear { get; set; }
        public bool OneTimeEvent { get; set; }
    }
}
