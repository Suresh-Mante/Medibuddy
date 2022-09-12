﻿using Medibuddy.Models;

namespace Medibuddy.Repositories
{
    public interface IMedicineRepository
    {
        public Medicine Create(Medicine medicine);
        public Medicine Get(int Id);
        public IEnumerable<Medicine> Get();
        public Medicine Update(int Id, Medicine medicine);
        public Medicine Delete(int Id);
    }
}
