using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FileService.Models
{
    [Serializable]
    public class Confirmation
    {
        public bool success;
        public String reason;

        public Confirmation(bool success, String reason)
        {
            this.success = success;
            this.reason = reason;
        }
    }
}