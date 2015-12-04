using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Models
{
    public class DetailParentModel
    {
        public ContactViewModel ContactViewModel { get; set; }
        public Job Job { get; set; }
    }
}