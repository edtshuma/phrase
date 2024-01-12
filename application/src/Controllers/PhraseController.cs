using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Mvc.Filters;
﻿using AutoMapper;
using Phrase.Entities;
using Phrase.Helpers;
using Phrase.Models;
using Phrase.Services;



namespace Phrase.Controllers
{

[ApiController]
[Route("/[controller]/[action]")]
public class PhraseController : ControllerBase
{
   
        private IPalindromeService _palindromeService;
        private IMapper _mapper;
        private DataContext _context;
  
        public PhraseController(IPalindromeService palindromeService, IMapper mapper,DataContext context)
        {
            _palindromeService = palindromeService;
           _mapper = mapper;
           _context = context;
           
        }

   public class ReadinessCheckFilterAttribute : ActionFilterAttribute
    {
        private readonly DateTime startTime;

        public ReadinessCheckFilterAttribute(DateTime startTime)
        {
            this.startTime = startTime;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!IsReady())
            {
                context.Result = new NotFoundObjectResult("Not ready");
            }

            base.OnActionExecuting(context);
        }

        private bool IsReady()
        {
            return DateTime.Now > startTime.AddSeconds(10);
        }
    }

    [HttpGet]
    [ActionName("status")]
    [ServiceFilter(typeof(ReadinessCheckFilterAttribute))]
    public IActionResult status()
    {
        return Ok("Ok");
    }

     [HttpGet]
     [ActionName("")]
     public async Task<IActionResult> HelloWorld()
     {
        
         return Ok("Hello, World!");
     }

    [HttpGet]
    [ActionName("admin")]
    public IActionResult admin()
    {
        return Ok("admin area");
    }


    [ActionName("palindrom")]
    [Route("{text}")]
    public async Task<IActionResult> palindrom(string text)
    {
        text = text.Substring(0, Math.Min(text.Length, 200));

        if (_palindromeService.IsPalindrome(text))
        {
            var palindrom = new Palindrom { Text = text };
            _context.Palindroms.Add(palindrom);
            _context.SaveChanges();
            return Ok("Text is palindrom");
        }

        return Ok("Text is not palindrom");
    }

    
}

}


