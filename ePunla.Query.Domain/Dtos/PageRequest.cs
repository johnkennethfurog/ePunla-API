﻿using System;
using ePunla.Query.Domain.Enums;

namespace ePunla.Query.Domain.Dtos
{
    public class PageRequest
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string SortBy { get; set; }
        public SortDirection SortDirection { get; set; }
    }
}