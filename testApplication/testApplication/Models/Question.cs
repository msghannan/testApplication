﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testApplication.Model
{
    public class Question
    {
        public int ID { get; set; }
        public string Quest { get; set; }

        public Question (int id, string question)
        {
            this.ID = id;
            this.Quest = question;
        }

        public static implicit operator ObservableCollection<object>(Question v)
        {
            throw new NotImplementedException();
        }
    }
}