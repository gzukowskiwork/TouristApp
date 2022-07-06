﻿namespace TouristAppBackend.Application.Common.Interfaces
{
    public interface ICurrentUserService
    {
        public string Email { get; set; }
        public bool IsAuthenticated { get; set; }
    }
}
