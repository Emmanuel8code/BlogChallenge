﻿using BlogChallenge.Models.Entities;
using BlogChallenge.Models.Interfaces;
using BlogChallenge.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogChallenge.Controllers
{
    public class PostsController : Controller
    {
        private readonly IPostService _postService;
        private readonly ICategoryService _categoryService;
        private readonly IImageFileService _imageFileService;

        public PostsController(IPostService postService, ICategoryService categoryService, IImageFileService imageFileService)
        {
            _postService = postService;
            _categoryService = categoryService;
            _imageFileService = imageFileService;
        }


        // GET: PostsController
        public async Task<IActionResult> Index()
        {
            return View(await _postService.GetAllPosts());
        }

        // GET: PostsController/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _postService.GetPostById((int)id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // GET: PostsController/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.itemsOfCategories = await _categoryService.GetSelectListCategories();

            return View();
        }

        // POST: PostsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] PostViewModel postViewModel)
        {
            if (ModelState.IsValid)
            {
                string imageFileName = null;

                if (postViewModel.Image != null)
                {
                    imageFileName = await _imageFileService.UploadImage(postViewModel.Image);
                }
                
                Post post = new()
                {
                    Title = postViewModel.Title,
                    Content = postViewModel.Content,
                    Image = imageFileName,
                    CategoryId = postViewModel.CategoryId
                };

                await _postService.AddPost(post);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.itemsOfCategories = await _categoryService.GetSelectListCategories();

            return View(postViewModel);
        }

        // GET: PostsController/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _postService.GetPostById((int)id);
            if (post == null)
            {
                return NotFound();
            }

            PostViewModel postViewModel = new()
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content,
                //Image = "a completar",
                CategoryId = post.CategoryId
            };

            ViewBag.itemsOfCategories = await _categoryService.GetSelectListCategories();

            return View(postViewModel);
        }

        // POST: PostsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Content,Image")] PostViewModel postViewModel)
        {
            if (id != postViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Post post = new()
                    {
                        Id = postViewModel.Id,
                        Title = postViewModel.Title,
                        Content = postViewModel.Content,
                        Image = "a completar",
                        CategoryId = postViewModel.CategoryId
                    };

                    await _postService.UpdatePost(post);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_postService.ExistPost(postViewModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(postViewModel);
        }

        // GET: PostsController/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _postService.GetPostById((int)id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // POST: PostsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var post = await _postService.DeletePost(id);

            _imageFileService.DeleteImage(post.Image);

            return RedirectToAction(nameof(Index));
        }
    }
}
