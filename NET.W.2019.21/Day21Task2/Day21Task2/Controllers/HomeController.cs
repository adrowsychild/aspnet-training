using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Day21Task2.Models;

namespace Day21Task2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<Image> images = new List<Image>()
            {
                new Image
                {
                    Id = 1,
                    Description = "Cubes",
                    Path = @"~/GalleryImages/cubes.jpg",
                    ThumbPath = @"~/GalleryImages/Thumb/cubes.jpg",
                },

                new Image
                {
                    Id = 2,
                    Description = "Eye",
                    Path = @"~/GalleryImages/eye.jpg",
                    ThumbPath = @"~/GalleryImages/Thumb/eye.jpg",
                },

                new Image
                {
                    Id = 3,
                    Description = "Forest",
                    Path = @"~/GalleryImages/forest.jpg",
                    ThumbPath = @"~/GalleryImages/Thumb/forest.jpg",
                },

                new Image
                {
                    Id = 4,
                    Description = "Hand",
                    Path = @"~/GalleryImages/hand.jpg",
                    ThumbPath = @"~/GalleryImages/Thumb/hand.jpg",
                },

                new Image
                {
                    Id = 5,
                    Description = "Room",
                    Path = @"~/GalleryImages/room.jpg",
                    ThumbPath = @"~/GalleryImages/Thumb/room.jpg",
                },
            };

            ViewBag.Images = images;

            return View();
        }
    }
}