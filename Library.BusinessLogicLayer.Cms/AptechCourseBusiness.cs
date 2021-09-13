using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Cms.DataModel;
using Library.Cms.DataAccessLayer;

namespace Library.Cms.BusinessLogicLayer
{
    public class AptechCourseBusiness: IAptechCourseBusiness
    {
        private IAptechCourseRepository _res;
        public AptechCourseBusiness(IAptechCourseRepository res)
        {
            _res = res;
        }

        public string CreateNewCourse(AptechCourseModel model)
        {
            if(model.course_id == Guid.Empty)
            {
                model.course_id = Guid.NewGuid();
            }
            
            string result = _res.CreateCourse(model);
            return result;
        }
    }
}
