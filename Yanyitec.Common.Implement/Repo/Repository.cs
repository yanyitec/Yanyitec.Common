using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Yanyitec.Repo
{
    public class Repository : DbContext, IRepository
    {
        public Repository() : base() {

        }

        
    }
}
