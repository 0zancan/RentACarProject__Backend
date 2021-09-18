using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static Core.Utilities.Helpers.FileHelpers.ImageFileHelper;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        private string sourcePath = "C:\\Users\\W10\\source\\repos\\RentACarProject_Backend\\_Gallery\\";

        [SecuredOperation("admin,product.add")]
        public IResult AddCarImage(IFormFile formFile, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckIfImageCountOfCarCorrect(carImage.CarId));

            if (result != null)
            {
                return result;
            }

            var imagePathResult = FileUpload.Add(formFile);

            if (!imagePathResult.Success)
                return imagePathResult;

            carImage.ImagePath = imagePathResult.Data;
            carImage.Date = DateTime.Now.ToString();

            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImagAdded);
        }

        public IResult DeleteCarImage(IFormFile formFile, CarImage carImage)
        {
            var result = GetCarImagePathIfExistById(carImage.Id);
            if (!result.Success)
                return result;


            var deleteImageResult = FileUpload.Delete(result.Data);
            if (!deleteImageResult.Success)
            {
                return deleteImageResult;
            }

            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarImageDeleted);
        }

        public IDataResult<List<CarImage>> GetCarImagesByCarId(int carId)
        {
            var carImages = _carImageDal.GetAll(x => x.CarId == carId).ToList();

            //if (carImages.Count() == 0)
            //{
            //    // ???????????? TO DO
            //    carImages.ImagePath = FileUpload.GetDefaultImagePath();
            //}

            foreach (var carImage in carImages)
            {
                if (string.IsNullOrEmpty(carImage.ImagePath))
                {
                    carImage.ImagePath = FileUpload.GetDefaultImagePath();
                }
            }

            return new SuccessDataResult<List<CarImage>>(carImages, Messages.CarImagesListed);
        }

        public IResult UpdateCarImage(IFormFile formFile, CarImage carImage)
        {
            var result = GetCarImagePathIfExistById(carImage.Id);
            if (!result.Success)
                return result;


            var updateImage = FileUpload.Update(formFile, result.Data);
            if (!updateImage.Success)
                return updateImage;

            carImage.ImagePath = updateImage.Data;
            carImage.Date = DateTime.Now.ToString();
            carImage.CarId = carImage.CarId == 0 ? _carImageDal.Get(x => x.Id == carImage.Id).CarId : carImage.CarId;

            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImageUpdated);
        }

        private IResult CheckIfImageCountOfCarCorrect(int carId)
        {
            int imageCount = _carImageDal.GetAll(x => x.CarId == carId).Count();
            if (imageCount > 5)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }

        private IDataResult<string> GetCarImagePathIfExistById(int id)
        {
            var result = _carImageDal.Get(x => x.Id == id);
            if (result == null)
            {
                return new ErrorDataResult<string>(Messages.ImagePathExist);
            }
            return new SuccessDataResult<string>(result.ImagePath, null);
        }
    }
}
