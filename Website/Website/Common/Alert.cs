﻿using System;

namespace Common
{
    [Serializable]
    public class Alert
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public AlertType AlertType { get; set; }

        public Alert(AlertType alertType, string title, string description = null)
        {
            AlertType = alertType;
            Title = title; 
            Description = description;
        }

        public Alert() { }
    }
}
