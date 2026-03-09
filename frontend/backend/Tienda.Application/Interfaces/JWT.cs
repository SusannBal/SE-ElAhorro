using System;
using System.Collections.Generic;
using System.Text;
using Tienda.Domain.Entities;

public interface IJwtGenerator
{   
    string Generate(Usuario usuario);
}

