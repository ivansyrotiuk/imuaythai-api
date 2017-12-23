﻿using System;

namespace IMuaythai.DataAccess.Models
{
    public class ContestRing
    {
        public int Id { get; set; }
        public int ContestId { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public string Name { get; set; }

        public virtual Contest Contest { get; set; }
    }
}
