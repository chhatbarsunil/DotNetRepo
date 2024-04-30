using Core_MVCMediatRApp.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi_MVCMediateRApp.ViewModels;

namespace WebApi_MVCMediateRApp.Application.UserProcessor.Queries
{
    public class GetUsersQuery : IRequest<List<UserViewModel>>
    {
    }
}
