﻿using System.Collections.Generic;

namespace MagusAppGateway.Models.Dtos
{
    public class ClientRedirectUriConfigDto
    {
        public int ClientId { get; set; }

        public List<ClientRedirectUriEditDto> clientRedirectUriEditDtos { get; set; }
    }
}
