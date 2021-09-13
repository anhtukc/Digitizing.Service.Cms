using System;
using System.Collections.Generic;
using Library.Cms.DataModel;
namespace Library.Cms.DataAccessLayer
{
    public partial interface IAptechCourseRepository
    {
        string CreateCourse(AptechCourseModel model);
    }
}
