using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.BusinessRules;
using Core.Utilities.FileHelpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ImageManager : IImageService
    {
        IImageDal _carImageDal;

        public ImageManager(IImageDal carImageDAL)
        {
            _carImageDal = carImageDAL;
        }
        [ValidationAspect(typeof(ImageValidator))]

        public IResult Add(IFormFile file, Image carImage)
        {
            var imageCount = _carImageDal.GetAll(c => c.CarId == carImage.CarId).Count;

            if (imageCount >= 5)
            {
                return new ErrorResult("One car must have 5 or less images");
            }

            var imageResult = FileHelper.Upload(file);

            if (!imageResult.Success)
            {
                return new ErrorResult(imageResult.Message);
            }
            carImage.ImagePath = imageResult.Message;
            _carImageDal.Add(carImage);
            return new SuccessResult("Car image added");
        }
        [ValidationAspect(typeof(ImageValidator))]
        
        public IResult Delete(Image carImage)
        {
            var image = _carImageDal.Get(c => c.Id == carImage.Id);
            if (image == null)
            {
                return new ErrorResult("Image not found");
            }

            FileHelper.Delete(image.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult("Image was deleted successfully");
        }
        [ValidationAspect(typeof(ImageValidator))]
        
        public IResult Update(IFormFile file, int id)
        {
            var image = _carImageDal.Get(c => c.Id == id);
            if (image == null)
            {
                return new ErrorResult("Image not found");
            }

            var updatedFile = FileHelper.Update(file, image.ImagePath);
            if (!updatedFile.Success)
            {
                return new ErrorResult(updatedFile.Message);
            }
            image.ImagePath = updatedFile.Message;
            _carImageDal.Update(image);
            return new SuccessResult("Car image updated");
        }
        [ValidationAspect(typeof(ImageValidator))]
        public IDataResult<Image> Get(int id)
        {
            return new SuccessDataResult<Image>(_carImageDal.Get(p => p.Id == id));
        }
        
        public IDataResult<List<Image>> GetAll()
        {
            return new SuccessDataResult<List<Image>>(_carImageDal.GetAll());
        }
        [ValidationAspect(typeof(ImageValidator))]

        public IDataResult<List<Image>> GetImagesByCarId(int id)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageNull(id));

            if (result != null)
            {
                return new ErrorDataResult<List<Image>>(result.Message);
            }

            return new SuccessDataResult<List<Image>>(CheckIfCarImageNull(id).Data);
        }


        //business rules

        private IResult CheckImageLimitExceeded(int carId)
        {
            var carImagecount = _carImageDal.GetAll(p => p.CarId == carId).Count;
            if (carImagecount >= 5)
            {
                return new ErrorResult(Messages.CarImageLimitExceeded);
            }

            return new SuccessResult();
        }

        private IDataResult<List<Image>> CheckIfCarImageNull(int id)
        {
            try
            {
                string path = @"\images\logo.jpg";
                var result = _carImageDal.GetAll(c => c.CarId == id).Any();
                if (!result)
                {
                    List<Image> carimage = new List<Image>();
                    carimage.Add(new Image { CarId = id, ImagePath = path, Date = DateTime.Now });
                    return new SuccessDataResult<List<Image>>(carimage);
                }
            }
            catch (Exception exception)
            {

                return new ErrorDataResult<List<Image>>(exception.Message);
            }

            return new SuccessDataResult<List<Image>>(_carImageDal.GetAll(p => p.CarId == id).ToList());
        }
        private IResult CarImageDelete(Image carImage)
        {
            try
            {
                File.Delete(carImage.ImagePath);
            }
            catch (Exception exception)
            {

                return new ErrorResult(exception.Message);
            }

            return new SuccessResult();
        }

        
    }
}
