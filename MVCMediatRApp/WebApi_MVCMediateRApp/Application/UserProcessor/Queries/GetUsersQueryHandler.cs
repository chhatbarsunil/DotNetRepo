
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi_MVCMediateRApp.Services;
using WebApi_MVCMediateRApp.ViewModels;

namespace WebApi_MVCMediateRApp.Application.UserProcessor.Queries
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, List<UserViewModel>>
    {
        private readonly IUserService _userService;

        public GetUsersQueryHandler(IUserService userService)
        {
            _userService = userService;
        }


        public async Task<List<UserViewModel>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var result = await _userService.GetAllUsers();
            return result;
        }
    }
}
