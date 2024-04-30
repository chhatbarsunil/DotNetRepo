using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi_MVCMediateRApp.ViewModels;

namespace WebApi_MVCMediateRApp.Application.UserProcessor.Queries
{
    public class GetUserByIdQuery : IRequest<UserViewModel>
    {
        public int Id { get; set; }
        public GetUserByIdQuery(int id) {
            Id = id;
        }
    }
    
}
