using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, SqlContext>, IProductDal
    {
        public List<ProductDetailDto> GetProductDetails()
        {
            using(SqlContext context=new SqlContext())
            {
                var result = from p in context.Products
                             join c in context.Colors
                             on p.ColorId equals c.ColorId
                             join i in context.Brands
                             on p.BrandId equals i.BrandId
                             select new ProductDetailDto
                             {
                                 ProductId = p.ID,
                                 Description = p.Description,
                                 ColorName = c.ColorName,
                                 BrandName = i.BrandName



                             };
                return result.ToList();

            }
        }
    }
}
