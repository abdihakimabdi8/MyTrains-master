﻿using MyTrains.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTrains.Core.Contracts.Repository
{
    public interface ISavedBeneficiaryRepository
    {
        Task<IEnumerable<SavedBeneficiary>> GetSavedBeneficiaryForUser(int userId);

        Task AddSavedBeneficiary(int userId, int beneficiaryId);
    }
}