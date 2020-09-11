﻿using System.Collections.Generic;

namespace MagusAppGateway.Models.Dtos
{
    public class ApiScopeUpdateDto
    {
        public int Id { get; set; }

        public bool Enabled { get; set; }

        public string Name { get; set; }

        public string DisplayName { get; set; }

        public string Description { get; set; }

        public bool Required { get; set; }

        public bool Emphasize { get; set; }

        public bool ShowInDiscoveryDocument { get; set; }

        public List<ApiScopeClaimUpdateDto> UserClaims { get; set; }

        public List<ApiScopePropertyUpdateDto> Properties { get; set; }
    }
}
