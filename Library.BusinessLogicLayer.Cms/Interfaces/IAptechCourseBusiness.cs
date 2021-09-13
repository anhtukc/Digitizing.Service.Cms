using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Cms.DataModel;
namespace Library.Cms.BusinessLogicLayer
{
    public partial interface IAptechCourseBusiness
    {
        string CreateNewCourse(AptechCourseModel model);
    }
}
