﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MagusAppGateway.Models.Dtos
{
    public class AuthenticationOptionsEditDto
    {
        public Guid? Id { get; set; }

        /// <summary>
        /// APIScope名称
        /// </summary>
        public string AuthenticationProviderKey { get; set; }

        public Guid? RoutesGuid { get; set; }

        public RoutesEditDto Routes { get; set; }
    }
}
