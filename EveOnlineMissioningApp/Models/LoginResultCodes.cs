using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EveOnlineMissioningApp.Models
{

    /**
     * Login result codes.
     * 1000s represent successes
     * 2000s represent errors
     **/
    public enum LoginResultCodes
    {
        ValidCredentials = 1000,
        NoCredentialsGiven = 2001,
        InvalidCredentials = 2002,
        NoAccountFound = 2003,
    }
}