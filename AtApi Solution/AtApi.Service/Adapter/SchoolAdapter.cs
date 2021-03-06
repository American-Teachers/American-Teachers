﻿using AtApi.Model.At;
using System.Linq;

namespace AtApi.Service.Adapter
{
    public class SchoolAdapter : AtBaseAdapter<School>
    {
         
        public SchoolAdapter(AtDbContext atDbContext) : base(atDbContext)
        {

        }
        public School GetOne(int id)
        {
            return atDbContext.Schools.Where(_ => _.Id == id).SingleOrDefault();
        }

        //public School Update(School model)
        //{
        //    var old = GetOne(model.Id);
        //    old.Name = model.Name;            
        //    atDbContext.SaveChanges();
        //    return old;
        //}
    }
}
