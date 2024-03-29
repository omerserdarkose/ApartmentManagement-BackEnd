﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApartmentManagement.Core.Utilities.Result;
using ApartmentManagement.Entities.Dtos.Apartment;
using ApartmentManagement.Entities.Dtos.User;

namespace ApartmentManagement.Business.Abstract
{
    public interface IApartmentService
    {
        IResult Add(ApartmentAddDto apartmentAddDto);
        IResult Update(ApartmentUpdateDto apartmentUpdateDto);
        IResult UpdateUser(ApartmentUserUpdateDto apartmentUpdateDto);

        IResult UpdateStatus(int apartmentId,bool status);
        IResult Delete(int apartmentId);
        IDataResult<List<ApartmentViewDto>> GetAll();

        IDataResult<List<UserViewDto>> GetAllResident();
        List<int> GetIdList();
        int GetIdByResidentId(int residentId);
        bool IsHirer(int residentId);
    }
}
