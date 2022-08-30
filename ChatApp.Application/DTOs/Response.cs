﻿namespace ChatApp.Application.DTOs
{
    public class Response
    {
        public string? Message { get; set; }
        public bool IsSuccess { get; set; }
        public IEnumerable<string>? Errors { get; set; }
        public DateTime? ExpireDate { get; set; }
    }
}
