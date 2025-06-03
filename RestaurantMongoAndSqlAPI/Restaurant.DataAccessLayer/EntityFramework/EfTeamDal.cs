using Restaurant.DataAccessLayer.Abstract;
using Restaurant.DataAccessLayer.Context;
using Restaurant.DataAccessLayer.Repositories;
using Restaurant.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.DataAccessLayer.EntityFramework
{
    public class EfTeamDal:GenericRepository<Team>,ITeamDal
    {
        public EfTeamDal(MongoContext context) : base(context.GetCollection<Team>("Teams"))
        {
            
        }
    }
}
