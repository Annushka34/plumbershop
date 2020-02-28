using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DAL;
using DAL.Models;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PlumberShop.Controllers
{
    //[ApiController]
    [Route("[controller]")]
    public class PostController : Controller
    {
        private readonly EfContext _context;
        public PostController(EfContext context)
        {
            _context = context;
        }

      

        [HttpGet("All")]
        public IActionResult GetAll()
        {
            return Ok(_context.Posts.ToList());
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            return Ok(_context.Posts.FirstOrDefault(x => x.Id == id));
        }

        [HttpGet("GetByTheme")]
        public IActionResult GetByTheme(string theme)
        {
            return Ok(_context.Posts.Where(x=>x.Theme == theme).ToList());
        }
        [HttpGet("Create")]
        public IActionResult Create()
        {
            ViewBag.Test = _context.Posts.Count();
            Post newPost = new Post();
            return View(newPost);
        }

        [HttpPost("Create")]
        public IActionResult Create([FromForm] IFormCollection formData)
        {
            var text = formData.FirstOrDefault(x => x.Key == "Text").Value.ToString();
            var theme = formData.FirstOrDefault(x => x.Key == "Theme").Value.ToString();


            FileInfo fileInfo = new FileInfo(formData.Files[0].FileName);
            var fn = Guid.NewGuid() + fileInfo.Extension;
            var memoryStream = formData.Files[0].OpenReadStream();



            var ftpRequest = (FtpWebRequest)WebRequest.Create("ftp://198.37.116.25/" + fn);
            ftpRequest.ConnectionGroupName = "myConnectionGroup";
            ftpRequest.Credentials = new NetworkCredential("annushka".Normalize(), "annushka123".Normalize());
            ftpRequest.EnableSsl = false;
            ftpRequest.Method = WebRequestMethods.Ftp.UploadFile;

            //Буфер для загружаемых данных
            byte[] file_to_bytes = new byte[formData.Files[0].Length];
            //Считываем данные в буфер
        
            formData.Files[0].OpenReadStream().Read(file_to_bytes, 0, (int)formData.Files[0].Length);
           

            //Поток для загрузки файла 
            Stream writer = ftpRequest.GetRequestStream();

            writer.Write(file_to_bytes, 0, file_to_bytes.Length);
            writer.Close();


           




            //        byte[] fileContents = new byte[(int)formData.Files[0].Length];
            //        FileInfo fileInfo = new FileInfo(formData.Files[0].FileName);
            //            var fn =  Guid.NewGuid() + fileInfo.Extension;
            //        formData.Files[0].OpenReadStream().Read(fileContents, 0, (int)formData.Files[0].Length);

            //        FtpWebRequest request =
            //(FtpWebRequest)WebRequest.Create("ftp://annushka@santech.somee.com/www.santech.somee.com/wwwroot/img/"+fn);
            //        request.Credentials = new NetworkCredential("annushka", "annushka123");
            //        request.Method = WebRequestMethods.Ftp.UploadFile;



          
            Post post = new Post();
            post.Date = DateTime.Now;
            post.AuthorId = 1;
            post.Img = fn;
            post.Likes = 0;
            post.Text = text;
            post.Theme = theme;
            _context.Posts.Add(post);
            _context.SaveChanges();
            return Redirect("/Home/Index");
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            Post post = _context.Posts.FirstOrDefault(x => x.Id == id);

            _context.Remove(post);
            _context.SaveChanges();
            return Ok("deleted");
        }

        [HttpPut("Edit")]
        public IActionResult Edit([FromBody] Post post)
        {
            //Post editedPost = _efContext.Posts.FirstOrDefault(x => x.Id == post.Id);
            //editedPost.Author = post.Author ?? editedPost.Author;
            //editedPost.Likes = post.Likes ?? editedPost.Likes;
            //editedPost.Text = post.Text ?? editedPost.Text;
            //editedPost.Theme = post.Theme ?? editedPost.Theme;
            //_efContext.SaveChanges();
            return Ok("saved");
        }

        //---Users---
        [HttpGet("Users")]
        public IActionResult Users()
        {
            ViewBag.Test = _context.Users.Count();
            return View(_context.Users.ToList());
        }

        //[HttpGet("Register")]
        //public IActionResult Register()
        //{
        //    User user = new User();
        //    return View(user);
        //}


        [HttpPost("Register")]
        public IActionResult Register([FromBody]User user)
        {
            user.Role = "user";
            _context.Users.Add(user);
            _context.SaveChanges();
            return Redirect("/Post/Users");
        }

        [HttpPost("Login")]
        public string Login([FromBody]User user)
        {
            var u = _context.Users.Where(x => x.Email == user.Email && x.Password == user.Password).FirstOrDefault();
            return u.Role;
        }

    }
}