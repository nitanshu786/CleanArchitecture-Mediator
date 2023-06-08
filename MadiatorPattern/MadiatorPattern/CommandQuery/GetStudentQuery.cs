using MadiatorPattern.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MadiatorPattern.CommandQuery
{
    public class GetStudentQuery: IRequest<List<Student>>
    {
    }
}
