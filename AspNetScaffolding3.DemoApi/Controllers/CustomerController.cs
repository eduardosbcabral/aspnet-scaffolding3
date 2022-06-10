﻿using AspNetScaffolding.DemoApi.Entities;
using AspNetScaffolding.DemoApi.Models;
using AspNetScaffolding.Extensions.Logger;
using AspNetScaffolding.Extensions.Mapper;
using AspNetSerilog;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using WebApi.Models.Response;

namespace AspNetScaffolding.Controllers
{
    public class CustomerController : BaseController
    {
        public LogAdditionalInfo LogAdditionalInfo { get; set; }

        public CustomerController(LogAdditionalInfo logAdditionalInfo)
        {
            LogAdditionalInfo = logAdditionalInfo;
        }

        /// <summary>
        /// Get Customer
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("customers/{customerId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ErrorsResponse), 400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult Get(CustomerRequest request)
        {
            LogAdditionalInfo.Data.Add("CustomerId", request.CustomerId);

            StaticSimpleLogger.Info("teste teste teste", "123", new {request});

            return Ok(new
            {
                request,
                test = "1",
                test_1 = "123",
                customer = new Customer("xx", "yy")
            });
        }

        /// <summary>
        /// Get Customer
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("customers/{customerId}/post")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ErrorsResponse), 400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult Post([FromBody] CustomerRequest3 request)
        {
            LogAdditionalInfo.Data.Add("CustomerId", request.CustomerId);

            StaticSimpleLogger.Info("teste teste teste", "requestKey", new { request });

            return Ok(new
            {
                request,
                test = "1",
                test_1 = "123",
                customer = new Customer("xx", "yy")
            });
        }

        [HttpGet("customers/{customerId}/string")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ErrorsResponse), 400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult GetString([FromRoute] string customerId)
        {
            return Ok(new { customerId });
        }

        [HttpGet("customers/{customerId}/none")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ErrorsResponse), 400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult GetNone(CustomerRequest2 request)
        {
            return Ok(request);
        }

        [HttpGet("customers/{customerId}/fromroute")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ErrorsResponse), 400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult GetFromRoute([FromRoute] CustomerRequest2 request)
        {
            return Ok(request);
        }

        [HttpPost("customers/{customerId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(Customer), 400)]
        public IActionResult Create2(CustomerRequest2 request2)
        {
            var customer = request2.As<Customer>();

            return Created("", customer);
        }

        [HttpGet("customers/{customerId}/test")]
        public IActionResult Create22(CustomerRequest2 request2)
        {
            var customer = request2.As<Customer>();

            return Created("", customer);
        }

        [HttpGet("customers/null")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ErrorsResponse), 400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult GetNull()
        {
            return CreateJsonResponse(ApiResponse.OK());
        }
    }
}
