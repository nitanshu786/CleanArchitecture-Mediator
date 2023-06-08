using MadiatorPattern.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MadiatorPattern.CommandQuery
{
    public class DeleteCommand:IRequest<int>
    {
        public int Id { get; set; }
    }
}
