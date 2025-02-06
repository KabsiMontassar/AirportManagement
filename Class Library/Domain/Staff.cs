﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Library.Domain
{
    public class Staff : Passenger
    {
        public DateTime EmploymentDate { get; set; }
        public string Function { get; set; }
        public double Salary { get; set; }

        public override void PassengerType()
        {
            base.PassengerType(); 
            Console.WriteLine("I am a Staff Member");
        }
        public override string ToString()
        {
            return base.ToString() + $", Function: {Function}, Salary: {Salary}, Employment Date: {EmploymentDate.ToShortDateString()}";
        }
    }
}
