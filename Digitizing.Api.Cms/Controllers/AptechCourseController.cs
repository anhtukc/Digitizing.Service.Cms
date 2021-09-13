using System;
using Library.Common.Response;
using Library.Common.Message;
using Library.Common.Helper;
using Microsoft.AspNetCore.Mvc;
using Library.Cms.DataModel;
using Library.Cms.BusinessLogicLayer;
using Microsoft.AspNetCore.Hosting;
using Library.Common.Caching;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
namespace Digitizing.Api.Cms.Controllers
{
    [Route("api/aptech-course")]
    public class AptechCourseController : BaseController
    {
        private IWebHostEnvironment _env;
        private IAptechCourseBusiness _AptechCourseBus;
        public AptechCourseController(ICacheProvider redis, IConfiguration configuration, IHttpContextAccessor httpContextAccessor, IWebHostEnvironment env, IAptechCourseBusiness aptechCourseBus) : base(redis, configuration, httpContextAccessor)
        {
            _env = env ?? throw new ArgumentNullException(nameof(env));
            _AptechCourseBus = aptechCourseBus;
        }

        [Route("create-course")]
        [HttpPost]
        public async Task<ResponseMessage<AptechCourseModel>> CreateNewAptechCourse([FromBody] AptechCourseModel model)
        {
            var response = new ResponseMessage<AptechCourseModel>();
            try
            {
                model.created_by_user_id = CurrentUserId;
                
                var result = await Task.FromResult(_AptechCourseBus.CreateNewCourse(model));
                if(result == "add course success")
                {
                    response.Data = model;
                    response.MessageCode = MessageCodes.CreateSuccessfully;
                }
                else
                {
                    response.MessageCode = MessageCodes.CreateFail;
                }

            }
            catch(Exception ex)
            {
                response.MessageCode = ex.Message;
            }
             
            return response;
        }

        [Route("test")]
        [HttpGet]
        public string test()
        {
            return "ss";
        }

    }
}
