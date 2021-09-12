using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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

        public IResult AddCarImage(CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckIfImageCountOfCarCorrect(carImage.CarId));

            if (result != null)
            {
                return result;
            }

            FileInfo fi = new FileInfo(carImage.ImagePath);
            carImage.Date = DateTime.Now.ToString("MM/dd/yyyy");
            string fileName = carImage.ImagePath;
            string targetPath = sourcePath + carImage.CarId;

            if (!Directory.Exists(targetPath))
            {
                Directory.CreateDirectory(targetPath);
            }

            string sourceFile = Path.Combine(sourcePath, fileName);
            string destFile = Path.Combine(targetPath, String.Format("{0}_{1}{2}", carImage.CarId, carImage.Id, fi.Extension));
            File.Copy(sourceFile, destFile, true);

            carImage.ImagePath = destFile;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImagAdded);
        }

        public IResult DeleteCarImage(CarImage carImage)
        {
            var image = _carImageDal.Get(x => x.Id == carImage.Id);

            if (image == null)
            {
                return new ErrorDataResult<CarImage>(carImage, Messages.CarImageNotFound);
            }

            File.Delete(image.ImagePath);
            _carImageDal.Delete(carImage);

            return new SuccessResult(Messages.CarImageUpdated);
        }

        public IDataResult<List<CarImage>> GetCarImagesByCarId(int carId)
        {
            var carImages = _carImageDal.GetAll(x => x.CarId == carId).ToList();

            if (carImages.Count == 0)
            {
                //DEFAULT FOTO GETİRİLECEK! TO DO
                List<CarImage> defaultImage = _carImageDal.GetAll(x => x.CarId == 0).ToList();
                return new SuccessDataResult<List<CarImage>>(defaultImage, Messages.CarImagesListed);
            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.CarImagesListed);

        }

        public IResult UpdateCarImage(CarImage carImage)
        {
            FileInfo fi = new FileInfo(carImage.ImagePath);
            carImage.Date = DateTime.Now.ToString("MM/dd/yyyy");
            string fileName = carImage.ImagePath;
            string targetPath = sourcePath + carImage.CarId;

            if (!Directory.Exists(targetPath))
            {
                Directory.CreateDirectory(targetPath);
            }

            string sourceFile = Path.Combine(sourcePath, fileName);
            string destFile = Path.Combine(targetPath, String.Format("{0}_{1}{2}", carImage.CarId, carImage.Id, fi.Extension));
            File.Copy(sourceFile, destFile, true);

            carImage.ImagePath = destFile;
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImageUpdated);
        }

        private IResult CheckIfImageCountOfCarCorrect(int carId)
        {
            int imageCount = _carImageDal.GetAll(x => x.CarId == carId).Count();
            if (imageCount >= 5)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
    }
}
