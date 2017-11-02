using IMuaythai.DataAccess.Models;

namespace IMuaythai.Repositories.Institutions.Gyms
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
