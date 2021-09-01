using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    interface IColorDal
    {
        List<Color> GetAllColors();
        List<Color> GetColorById(int id);
        void AddColor(Color color);
        void UpdateColor(Color color);
        void DeleteColor(Color color);
    }
}
