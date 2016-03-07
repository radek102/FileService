using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FileService.Models
{
    public class ConfirmationWithList<T> : Confirmation
    {
        public List<T> list;
        public ConfirmationWithList(bool success, String reason, List<T> list) : base(success,reason)
        {
            this.list = list;
        }

    }
}