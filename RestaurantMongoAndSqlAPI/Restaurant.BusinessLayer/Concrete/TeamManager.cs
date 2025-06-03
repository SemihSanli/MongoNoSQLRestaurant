using Restaurant.BusinessLayer.Abstract;
using Restaurant.DataAccessLayer.Abstract;
using Restaurant.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.BusinessLayer.Concrete
{
    public class TeamManager : ITeamService
    {
        private readonly ITeamDal _teamDal;

        public TeamManager(ITeamDal teamDal)
        {
            _teamDal = teamDal;
        }

        public void TDelete(string id)
        {
           _teamDal.Delete(id);
        }

        public Team TGetByID(string id)
        {
            return _teamDal.GetByID(id);
        }

        public List<Team> TGetList()
        {
            return _teamDal.GetList();
        }

        public void TInsert(Team t)
        {
           _teamDal.Insert(t);
        }

        public void TUpdate(Team t)
        {
           _teamDal.Update(t);
        }
    }
}
