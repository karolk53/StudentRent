﻿using System.Text.Json;
using RentAPI.Helpers;

namespace RentAPI.Extensions;

public static class HttpExtensions
{
    public static void AddPaginationHeader(this HttpResponse response, PaginationHeader paginationHeader)
    {
        var jsonOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
        response.Headers.Add("Pagination", JsonSerializer.Serialize(paginationHeader, jsonOptions));
        response.Headers.Add("Access-Control-Expose-Headers", "Pagination");
    }
}