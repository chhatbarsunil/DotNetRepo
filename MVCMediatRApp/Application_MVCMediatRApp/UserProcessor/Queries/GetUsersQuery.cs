using Core_MVCMediatRApp.Entity;
using Core_MVCMediatRApp.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application_MVCMediatRApp.UserProcessor.Queries
{
    public class GetUsersQuery : IRequest<List<UserViewModel>>
    {
    }
}
