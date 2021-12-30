﻿using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
  public   interface IRentalService
    {
        IDataResult<Rental> GetById(int rentalId);

        IDataResult<List<Rental>> GetAll();

        IResult Add(Rental rental);

        IResult Update(Rental rental);

        IResult Delete(Rental rental);
    }
}
