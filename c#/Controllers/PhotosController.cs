using Microsoft.AspNetCore.Mvc;
using ProjectChanuka.Classes_and_Interfaces;

namespace ProjectChanuka.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PhotosController : Controller
    {
        private readonly IPhoto _Iphoto;

        public PhotosController(IPhoto iPhoto)
        {
            _Iphoto = iPhoto;
        }

        [HttpGet]
        [Route("api/GetPhotos")]

        public string GetPhotos()
        {
            return _Iphoto.Get();
        }

        [HttpPut]
        [Route("api/PutPhotos/{str}")]

        public void PutPhotos(string str)
        {
            _Iphoto.Get();
        }

        [HttpPost]
        [Route("api/PostPhoto")]
        public ActionResult<string> PostPhoto()
        {
            return _Iphoto.Post();
        }
        [HttpDelete]
        [Route("api/DeletePhoto")]

        public bool DeletePhotos()
        {
            return _Iphoto.Delete();
        }



    }

}

