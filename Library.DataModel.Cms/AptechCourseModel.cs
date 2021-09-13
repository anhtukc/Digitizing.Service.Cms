using System;

namespace Library.Cms.DataModel
{
    public partial class AptechCourseModel
    {
        public Guid course_id { get; set; }
        public string course_name { get; set; }
        public DateTime? started_day { get; set; }
        public int? course_duration { get; set; }
        public decimal? price { get; set; }

        public DateTime created_date_time { get; set; }
        public Guid created_by_user_id { get; set; }
        public Guid? lu_user_id { get; set; }
        public DateTime? lu_updated { get; set; }
        public int active_flag { get; set; }

    }
}
