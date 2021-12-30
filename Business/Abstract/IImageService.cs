using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
   public interface IImageService
    {
        IResult Add(IFormFile file, Image carImage);
        IResult Update(IFormFile file, int id);
        IResult Delete(Image carImage);
        IDataResult<Image> Get(int id);
        IDataResult<List<Image>> GetImagesByCarId(int id);
        IDataResult<List<Image>> GetAll();
    }
}
