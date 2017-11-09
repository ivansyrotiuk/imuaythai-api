using IMuaythai.DataAccess.Models;

namespace IMuaythai.Models.Institutions
{

    public class GymModel : InstitutionModel
    {


        public GymModel():base()
            {
            }
        public GymModel(Institution institution) : base(institution)
        {

        }


        public static explicit operator GymModel(Institution institution)
        {
            return new GymModel(institution);
           
        }
    }
}
