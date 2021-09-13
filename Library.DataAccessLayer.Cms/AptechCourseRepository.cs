using Library.Cms.DataModel;
using Library.Common.Helper;
using System;
using System.Collections.Generic;
using System.Data;

namespace Library.Cms.DataAccessLayer
{
    public class AptechCourseRepository : IAptechCourseRepository
    {
        private IDatabaseHelper _dbHelper;
        public AptechCourseRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public string CreateCourse(AptechCourseModel model)
        {
            try
            {
                var parameters = new List<IDbDataParameter>
                {
                    _dbHelper.CreateInParameter("@course_id",DbType.Guid,model.course_id),
                    _dbHelper.CreateInParameter("@course_name",DbType.String,model.course_name),
                    _dbHelper.CreateInParameter("@started_day",DbType.Date,model.started_day),
                    _dbHelper.CreateInParameter("@course_duration",DbType.Int32,model.course_duration),
                    _dbHelper.CreateInParameter("@price",DbType.Decimal,model.price),
                    _dbHelper.CreateInParameter("@created_by_user_id",DbType.Guid,model.created_by_user_id),
                    _dbHelper.CreateOutParameter("@OUT_ERR_CD", DbType.Int32, 10),
                    _dbHelper.CreateOutParameter("@OUT_ERR_MSG", DbType.String, 255)
                };
                var result = _dbHelper.CallToValueWithTransaction("dbo.aptech_course_create_course_anhtu", parameters);
                if ((result != null && !string.IsNullOrEmpty(result.ErrorMessage)) && result.ErrorCode != 0)
                {
                    throw new Exception(result.ErrorMessage);
                }
                return "add course success";
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
