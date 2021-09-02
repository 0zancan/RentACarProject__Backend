﻿using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager()
        {
        }

        public BrandManager(IBrandDal branDal)
        {
            _brandDal = branDal;
        }

        public List<Brand> GetAll()
        {
            return _brandDal.GetAll();
        }

        public List<Brand> GetBrandById(int id)
        {
            return _brandDal.GetAll(x => x.Id == id);
        }
    }
}
