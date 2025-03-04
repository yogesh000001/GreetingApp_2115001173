using Microsoft.AspNetCore.Mvc;
using ModelLayer.Model;
using BusinessLayer.Service;
using BusinessLayer.Interface;
using NLog;
namespace HelloGreetingApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HelloGreetingController : ControllerBase
    {
        
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
        IGreetingBL _greetBL;
        public HelloGreetingController(IGreetingBL greetBL)
        {
            _greetBL = greetBL;
            //_greetBL = greetBL;
        }
        /// <summary>
        /// Get method to get the greeting message
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get() {
            ResponseModel<string> responseModel = new ResponseModel<string>();
            responseModel.Message = "Hello to Greeting App API";
            responseModel.Success = true;
            responseModel.Data = "Hello, World!";
            _logger.Info("Get Method Executed");
            return Ok(responseModel);
        }
        /// <summary>
        /// Method to Post the Greeting Message
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>

        [HttpPost]
        public IActionResult Post(RequestModel requestModel) {
            ResponseModel<string> responseModel = new ResponseModel<string>();
            responseModel.Message = "Request receive successfully";
            responseModel.Success = true;
            responseModel.Data = $"key : {requestModel.key}, Value : {requestModel.value}";
            _logger.Info("Post Method Executed");
            return Ok(responseModel);
        }

        [HttpPut]
        public IActionResult Put(RequestModel requestModel) {
            ResponseModel<string> responseModel = new ResponseModel<string>();
            responseModel.Message = "Request receive successfully for put";
            responseModel.Success = true;
            responseModel.Data = $"key : {requestModel.key}, Value : {requestModel.value}";
            _logger.Info("Put Method Executed");
            return Ok(responseModel);
        }

        [HttpPatch]
        public IActionResult Patch(RequestModel requestModel) {
            ResponseModel<string> responseModel = new ResponseModel<string>();
            responseModel.Message = "Request receive successfully for patch";
            responseModel.Success = true;
            responseModel.Data = $"key : {requestModel.key}, Value : {requestModel.value}";
            _logger.Info("Patch Method Executed");
            return Ok(responseModel);
        }

        [HttpDelete]
        public IActionResult Delete(RequestModel requestModel) {
            ResponseModel<string> responseModel = new ResponseModel<string>();
            responseModel.Message = "Deleted Successfully";
            responseModel.Success = true;
            responseModel.Data = "";
            _logger.Info("Delete Method Executed");
            return Ok(responseModel);
        }

        [HttpGet("greet")]
        public IActionResult Greet()
        {
            ResponseModel<string> responseModel = new ResponseModel<string>();
            responseModel.Message = "Greet msg sent successfully";
            responseModel.Success = true;
            responseModel.Data = _greetBL.Greet();
            _logger.Info("Greet message sent successfully");
            return Ok(responseModel);
        }
    }
}
