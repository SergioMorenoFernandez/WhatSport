using System;
using System.Collections.Generic;

namespace WhatSport.Domain.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException(Dictionary<string, string[]> errorsDictionary)
        {
            ErrorsDictionary = errorsDictionary;
        }

        public Dictionary<string, string[]> ErrorsDictionary { get; }
    }
}
