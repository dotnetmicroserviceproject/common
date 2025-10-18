﻿using System.Text.Json.Serialization;


namespace common.Shared.Dtos
{
    public class FailureResponseDto<T>
    {
        [JsonPropertyName("data")]
        public T Data { get; set; }
        [JsonPropertyName("error")]
        public string Error { get; set; }
        [JsonPropertyName("message")]
        public string Message { get; set; } = "Request failed.";
        [JsonPropertyName("status_code")]
        public int StatusCode { get; set; } = 400;
    }
}
