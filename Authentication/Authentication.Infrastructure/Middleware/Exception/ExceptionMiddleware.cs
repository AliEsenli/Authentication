﻿using Authentication.Common.Constants;
using Authentication.Common.DTO;
using Authentication.Common.Exceptions;
using Authentication.Common.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using Serilog;
using System;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Infrastructure.Middleware
{
    public class ExceptionMiddleware
    {
        RequestDelegate next;
        private readonly Func<object, Task> _clearCacheHeadersDelegate;
        public ExceptionMiddleware(RequestDelegate _next)
        {
            _clearCacheHeadersDelegate = ClearCacheHeaders;
            next = _next;

        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (BusinessException ex)
            {
                await HandleAndWrapExceptionAsync(context, ex.Message, ex.ResponseCode, null, true,ex);
            }
            catch (Exception ex)
            {
                Log.Error($"Response Code: {"999"} Response: {ex.Message} ", ex);
                throw;

            }


        }

        private string GetResponseMessage(string responseCode, object[] parameters)
        {
            if (responseCode == ResponseCode.Success)
            {
                return string.Empty;
            }
            ResourceManager resourceManager = new ResourceManager(typeof(ResponseMessage_en_US));
            string message = resourceManager.GetString(string.Format("RC{0}", responseCode));
            if (parameters != null)
            {
                message = string.Format(message, parameters);
            }
            return message;
        }


        private async Task WriteResponseAsync(HttpContext context, string bodyJson)
        {
            context.Response.Headers.Add("Accept", "application/json");
            context.Response.Headers.Add("Content-Type", "application/json");
            context.Response.Headers.Add("Access-Control-Allow-Headers", "Content-Type, Access-Control-Allow-Headers, Authorization, X-Requested-With");
            context.Response.Headers.Add("Access-Control-Allow-Methods", "GET,POST,OPTIONS,DELETE,PUT");
            context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            byte[] data = ASCIIEncoding.ASCII.GetBytes(bodyJson);
            await context.Response.Body.WriteAsync(data, 0, data.Length);
        }

        private async Task HandleAndWrapExceptionAsync(HttpContext httpContext, string exceptionMessage, string responseCode, object[] parameters, bool business, Exception ex)
        {
            httpContext.Response.OnStarting(_clearCacheHeadersDelegate, httpContext.Response);
            if (business)
            {
                exceptionMessage = this.GetResponseMessage(responseCode, parameters);
            }

            ResponseDTOBase response = new ResponseDTOBase();
            response.responseInfo.responseCode = responseCode;
            response.responseInfo.message = exceptionMessage;
            response.responseInfo.IsSuccess = false;
            var responseJson = Newtonsoft.Json.JsonConvert.SerializeObject(response);
            Log.Error($"Response Code: {responseCode} Response: {responseJson} ", ex);
            await WriteResponseAsync(httpContext, responseJson);
        }

        private Task ClearCacheHeaders(object state)
        {
            var response = (HttpResponse)state;
            response.Headers[HeaderNames.CacheControl] = "no-cache";
            response.Headers[HeaderNames.Pragma] = "no-cache";
            response.Headers[HeaderNames.Expires] = "-1";
            response.Headers.Remove(HeaderNames.ETag);
            return Task.CompletedTask;
        }
    }
}