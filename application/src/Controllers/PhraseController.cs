using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Mvc.Filters;
﻿using AutoMapper;
using Phrase.Entities;
using Phrase.Helpers;
using Phrase.Models;
using Phrase.Services;
using StackExchange.Redis;
using Microsoft.Extensions.Caching.Distributed;


namespace Phrase.Controllers
{

[ApiController]
[Route("/[controller]/[action]")]
public class PhraseController : ControllerBase
{
   
        private IPalindromeService _palindromeService;
        private IMapper _mapper;
        private DataContext _context;

        private readonly IDistributedCache _distributedCache;
  
        public PhraseController(IPalindromeService palindromeService, IMapper mapper,DataContext context, IDistributedCache distributedCache)
        {
            _palindromeService = palindromeService;
            _distributedCache = distributedCache;
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
   
    [HttpGet]
    [ActionName("redis-hits")]
    public async Task<IActionResult> RedisHits()
    {
        try
        {
            var hits = await RetryWithDelayAsync(() => IncrementRedisHitsAsync(), 5, TimeSpan.FromSeconds(0.5));
            return Ok($"Redis hits {hits}");
        }
        catch (Exception)
        {
            return StatusCode(500, "No response from redis");
        }
    }

    private async Task<T> RetryWithDelayAsync<T>(Func<Task<T>> action, int retryCount, TimeSpan delay)
    {
        while (retryCount > 0)
        {
            try
            {
                return await action();
            }
            catch (Exception)
            {
                if (retryCount == 0)
                {
                    throw;
                }
                retryCount--;
                await Task.Delay(delay);
            }
        }
        return default; 
    }

    private async Task<long> IncrementRedisHitsAsync()
    {
        const string cacheKey = "hits";
        var existingHits = await _distributedCache.GetAsync(cacheKey);

        long hits = existingHits == null
            ? 1
            : BitConverter.ToInt64(existingHits);

        await _distributedCache.SetAsync(cacheKey, BitConverter.GetBytes(++hits));

        return hits;
    }
    
}

}


