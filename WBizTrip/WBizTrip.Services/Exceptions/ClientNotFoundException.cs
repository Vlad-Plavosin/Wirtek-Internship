﻿using System;



namespace Capify.CustomerJourney.Services.Exceptions;



public class ClientNotFoundException : Exception
{
    public ClientNotFoundException()
    {
    }



    public ClientNotFoundException(string message) : base(message)
    {
    }



    public ClientNotFoundException(string message, Exception innerException) : base(message, innerException)
    {
    }
}