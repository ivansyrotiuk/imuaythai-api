using System;
using System.Linq;
using System.Threading.Tasks;
using MuaythaiSportManagementSystemApi.Models;

namespace MuaythaiSportManagementSystemApi.Institutions.Gyms
{

    public class GymDto : InstitutionDto
    {


        public GymDto():base()
            {
            }
        public GymDto(Institution institution) : base(institution)
        {

        }


        public static explicit operator GymDto(Institution institution)
        {
            return new GymDto(institution);
           
        }
    }
}
