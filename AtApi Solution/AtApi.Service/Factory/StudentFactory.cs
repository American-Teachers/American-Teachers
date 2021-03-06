﻿using AtApi.Framework;
using AtApi.Model.At;
using AtApi.Service.Adapter;
using System.Threading.Tasks;

namespace AtApi.Service.Factory
{
    public class StudentFactory : BaseFactory<Student, AtDbContext>
    {
        public StudentFactory(IAdapter<Student> adapter, IContextAdapter<AtDbContext> contextAdapter) : base(adapter, contextAdapter)
        {

        }

        public override async Task<Student> UpdateAsync(Student model, bool saveChanges = true)
        {
            var old = await adapter.GetOneAsync(model.Id);
            old.AspUserId = model.AspUserId;
            old.FirstName = model.FirstName;
            old.LastName = model.LastName;
            old.EmailAddress = model.EmailAddress;
            old.PreferredName = model.PreferredName;
            old.Suffix = model.Suffix;
            old.Title = model.Title;
            return await base.UpdateAsync(old, saveChanges);

        }
    }
}
